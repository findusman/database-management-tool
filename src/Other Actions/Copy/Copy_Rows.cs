using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace DATA_MS
{
    public partial class Copy_Rows : DevExpress.XtraEditors.XtraForm
    {
        public Copy_Rows()
        {
            InitializeComponent();
        }




        GridHitInfo downhitinfo = null;

        private void load_tables()
        {

         
                   string query = "select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.tables order by name";

                   DAl obj = new DAl();
                   DataSet ds = new DataSet();      
                   ds =  obj.selection(query);
                   DataSet ds1 = new DataSet();
            
                 //  ds1 = ds.Clone();


                   gridControl1.DataSource = ds;
                   gridView1.PopulateColumns();


                 //  G_TABLES.DataSource = ds;
                  // GV_TABLES.PopulateColumns();
               //




                // load_data();
        

        }
        private void Copy_Rows_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dM_LUBRICANTSDataSet.tables' table. You can move, or remove it, as needed.
            this.tablesTableAdapter.Fill(this.dM_LUBRICANTSDataSet.tables);
            DAl.SERVERNAME = ".";
            DAl.DATABASE = "DM_LUBRICANTS";
            DAl.PASSWORD = "123";
            DAl.USERID = "sa";
           // load_tables();
        }

        private void G_TABLES_MouseDown(object sender, MouseEventArgs e)
        {
           


        }

        private void GV_TABLES_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            downhitinfo = null;
            GridHitInfo hitinfo = View.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitinfo.RowHandle >= 0)
                downhitinfo = hitinfo;
        }

        private void GV_TABLES_MouseMove(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (e.Button == MouseButtons.Left && downhitinfo.RowHandle == null)
            {

                Size dragsize = SystemInformation.DragSize;
                Rectangle dragrec = new Rectangle( new Point(downhitinfo.HitPoint.X - dragsize.Width/2 ,downhitinfo.HitPoint.Y - dragsize.Height/2),dragsize);
                if (!dragrec.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = View.GetDataRow(downhitinfo.RowHandle);
                    View.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downhitinfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            
            
            }
            
        }

        private void G_TABLES_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
            e.Effect = DragDropEffects.None;
            }
        }

        private void gridControl1_DragDrop(object sender, DragEventArgs e)
        {
             DevExpress.XtraGrid.GridControl Grid = sender as DevExpress.XtraGrid.GridControl;
             DataTable table = Grid.DataSource as DataTable;
             DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
             if (row != null && table != null && row.Table != table)
             {
                 table.ImportRow(row);
                 row.Delete();

             }
        }
    }
}