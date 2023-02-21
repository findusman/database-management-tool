using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DATA_MS.Other_Actions
{
    public partial class frm_Reset_identity : DevExpress.XtraEditors.XtraForm
    {
        public frm_Reset_identity()
        {
            InitializeComponent();
        }


        DAl obj_Dal = new DAl();
        string database_1 = string.Empty;
        private void load_databases()
        {
            try
            {


               


                DataSet ds = obj_Dal.selection("select name as [Names]  from sys.databases where database_id > 6");

                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES_1, "Names", "Names", ds.Tables[0], "");
               
                database_1 = LOOK_UP_DATABSES_1.Text;
               
               
            }
            catch (Exception ex)
            {

            }

        }


        DataSet ds = new DataSet();
        private void load_tables()
        {
            try
            {

                string query = "     select CAST(1 as Bit) as S,  c.name Columns, o.name Tables , IDENT_CURRENT(o.name) Max " +
                                " from sys.columns c  " +
                                " join sys.objects o on c.object_id = o.object_id  " +
                                    " join sys.schemas s on s.schema_id = o.schema_id  " +
                                    " where s.name = 'dbo'  " +
                                    " and o.is_ms_shipped = 0 and o.type = 'U'  " +
                                    " and c.is_identity = 1  " +
                                " order by o.name";



                ds = obj_Dal.selection("    use [" + database_1 + "] "+ query);

                G_TABLES_1.DataSource = ds.Tables[0];
                G_TABLES_1.MainView.PopulateColumns();


                GV_TABLES_1.Columns["S"].OptionsColumn.ReadOnly = false;
                GV_TABLES_1.Columns["S"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                GV_TABLES_1.Columns["S"].Width = 20;
                GV_TABLES_1.Columns["Columns"].OptionsColumn.ReadOnly = true;
                GV_TABLES_1.Columns["Tables"].OptionsColumn.ReadOnly = true;
                GV_TABLES_1.Columns["Max"].OptionsColumn.ReadOnly = true;
                GV_TABLES_1.BestFitColumns();
            }
            catch (Exception ex)
            {

            }

        }

        private void reset_identity()
        {
            try
            {


                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    if ((Boolean)ds.Tables[0].Rows[x]["S"] == true)
                    {

                        string query =  "    use [" + database_1 +"]    DBCC CHECKIDENT('" + ds.Tables[0].Rows[x]["Tables"] + "', RESEED, " + spinEdit1.Text + ")";

                        obj_Dal.ins_del_upd(query);
                    }


                  

                }
             
            }
            catch (Exception ex)
            {

            }

        }
        private void frm_Reset_identity_Load(object sender, EventArgs e)
        {
            load_databases();
            load_tables();
        }

        private void LOOK_UP_DATABSES_1_EditValueChanged(object sender, EventArgs e)
        {
            database_1 = LOOK_UP_DATABSES_1.Text;
            load_tables();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Are You Sure to Perform This Action !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {

                return;

            }
            reset_identity();
            load_tables();
        }

        private void ch_all_tables_1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}