using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace DATA_MS
{
    public partial class frmSQLStructure : DevExpress.XtraEditors.XtraForm
    {
        public frmSQLStructure()
        {
            InitializeComponent();
        }

        private void frmSQLStructure_Load(object sender, EventArgs e)
        {



            bind(gridControl_Tables, "select distinct(SQLTablesWithRelations.table_name) from SQLTablesWithRelations order by table_name");

        }

        public void bind(GridControl grid, string Query)
        {
            DAl obj = new DAl();
            DataSet ds = null;
            ds = obj.selection(Query);
            grid.DataSource = ds.Tables[0];
            grid.MainView.PopulateColumns();
            //grid.MainView.PopulateColumns();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {


                string name = gridView1.GetFocusedRowCellValue("table_name").ToString();
                bind(gridControl2, "select column_name, relation, primary_table,pk_column_name,fk_constraint_name from SQLTablesWithRelations where table_name = '" + name + "' ");
           

            }
            catch (Exception ex)
            {

            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = gridView1.GetFocusedRowCellValue("table_name").ToString();
                bind(gridControl2, "select column_name, relation, primary_table,pk_column_name,fk_constraint_name from SQLTablesWithRelations where table_name = '" + name + "' ");
            }
            catch (Exception ex)
            {

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string name = gridView1.GetFocusedRowCellValue("table_name").ToString();
                bind(gridControl2, "select column_name, relation, primary_table,pk_column_name,fk_constraint_name from SQLTablesWithRelations where table_name = '" + name + "'");
            }
            catch (Exception ex)
            {

            }
        }



    }
}