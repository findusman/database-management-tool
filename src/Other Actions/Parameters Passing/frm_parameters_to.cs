using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
namespace DATA_MS
{
    public partial class frm_parameters_to : DevExpress.XtraEditors.XtraForm
    {



        string conncetion_str = "";
           string tbl_procedures = "";

     static public   DataTable dt_return = new DataTable();
        public frm_parameters_to( string procedure , string connection_string )

        {
            InitializeComponent();



            SqlConnection obj_con = new SqlConnection();

            obj_con.ConnectionString = connection_string;
            obj_con.Open();


            conncetion_str = connection_string;
            tbl_procedures = procedure;

            SqlDataAdapter da = new SqlDataAdapter("select PARAMETER_NAME as Name , DATA_TYPE as Type , '' AS Value  from information_schema.parameters where specific_name='" + procedure + "'", obj_con);
            dt = new DataTable();
            da.Fill(dt);
            G_PARAMETERS.DataSource = dt;
            GV_PARAMETERS.PopulateColumns();
            GV_PARAMETERS.Columns["Type"].Width = 100;
            labelControl1.Text = dt.Rows.Count.ToString();


        }

        private void frm_parameters_to_Load(object sender, EventArgs e)
        {

        }


        RepositoryItemDateEdit RepositoryItemDateEdit = new RepositoryItemDateEdit();
        RepositoryItemCheckEdit RepositoryItemCheckEdit = new RepositoryItemCheckEdit();


        private void GV_PARAMETERS_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

            if (e.Column.FieldName != "Value") return;

            GridView gv = sender as GridView;
            string editorName = (string)gv.GetRowCellValue(e.RowHandle, "Type");

            switch (editorName)
            {
                case "datetime":
                    e.RepositoryItem = RepositoryItemDateEdit;
                    break;
                case "date":
                    e.RepositoryItem = RepositoryItemDateEdit;
                    break;
                case "time":
                    e.RepositoryItem = RepositoryItemDateEdit;
                    break;
                case "bit":
                    e.RepositoryItem = RepositoryItemCheckEdit;
                    break;
               
            }

        }


        static public DataTable dt = new DataTable();




        private void submit_parameters()
        {



            SqlConnection obj_con = new SqlConnection();
            obj_con.ConnectionString = conncetion_str;
            obj_con.Open();


            SqlCommand obj_cme = new SqlCommand();
            obj_cme.Connection = obj_con;
            obj_cme.CommandType = CommandType.StoredProcedure;
            obj_cme.CommandText = tbl_procedures;
            SqlParameter[] sql_param = new SqlParameter[dt.Rows.Count];

          

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                string name = dt.Rows[x]["Name"].ToString();
                var value = dt.Rows[x]["Value"];
                string type = dt.Rows[x]["Type"].ToString();

                if (type == "nvarchar" || type == "varchar" || type == "nchar" || type == "text")
                {
                    sql_param[x] = new SqlParameter(name, SqlDbType.NVarChar);
                    sql_param[x].Value = value.ToString();
                    obj_cme.Parameters.Add(sql_param[x]);
                }
                if (type == "datetime" || type == "date" || type == "time")
                {
                    sql_param[x] = new SqlParameter(name, SqlDbType.DateTime);
                    sql_param[x].Value =Convert.ToDateTime(value);
                    obj_cme.Parameters.Add(sql_param[x]);
                }
                if (type == "bit" || type == "binary")
                {
                    sql_param[x] = new SqlParameter(name, SqlDbType.Bit);
                    sql_param[x].Value = Convert.ToBoolean(value);
                    obj_cme.Parameters.Add(sql_param[x]);
                }
                if (type == "float" || type == "numeric")
                {
                    sql_param[x] = new SqlParameter(name, SqlDbType.Bit);
                    sql_param[x].Value = Convert.ToDouble(value);
                    obj_cme.Parameters.Add(sql_param[x]);
                }
                if (type == "char")
                {
                    sql_param[x] = new SqlParameter(name, SqlDbType.Char);
                    sql_param[x].Value = Convert.ToChar(value);
                    obj_cme.Parameters.Add(sql_param[x]);
                }

            }

            SqlDataReader dr;
          
           
            SqlDataAdapter da = new SqlDataAdapter(obj_cme);
            //dt_data = new DataTable();
            try
            {
                dr = obj_cme.ExecuteReader();
                dt_return.Rows.Clear();

                DataSet ds = new DataSet();

                dt_return = new DataTable();
                dt_return.Load(dr);
                ds.Tables.Clear();

                ds.Tables.Clear();

                ds.Tables.Add(dt_return);
                ds.EnforceConstraints = false;
                // da.Fill(dt_return);
                this.Close();
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "Data Ms");


            }
               //G_DATA.DataSource = dt_data;
            //GV_DATA.PopulateColumns();
            //LB_NO_DATA.Text = dt_data.Rows.Count.ToString();
           // GV_DATA.BestFitColumns();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            submit_parameters();
        }
    }
}