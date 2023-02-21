using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Repository;
using DATA_MS.Other_Actions.Copy;
using DATA_MS.Other_Actions;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Helpers;

namespace DATA_MS
{
    public partial class frm_Data_View_c : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_Data_View_c()
        {
            InitializeComponent();
        }









        string connection_string = "";
        private string connectionstring(Boolean database)
        {
            if (database == true)
            {

                connection_string = " Data Source = " + txt_server.Text + "; Database =" +  LOOK_UP_DATABSES.Text + " ; User Id=" + text_id.Text + ";  Password= " + txt_password.Text + "; ";

            }

            else if (database == false)
            {

                connection_string = " Data Source = " + txt_server.Text + "; Database = ; User Id=" + text_id.Text + ";  Password= " + txt_password.Text + "; ";


            }

            return connection_string;
        }

         DataTable dt_databases = new DataTable();

        private void load_databases()
        {
            try
            {

                SqlConnection obj_con = new SqlConnection();
                obj_con.ConnectionString = connectionstring(false);
                obj_con.Open();



                SqlDataAdapter da = new SqlDataAdapter("select   cast(database_id as nvarchar) as [Code] ,name as [Name]  from sys.databases where database_id > 6", obj_con);
                dt_databases.Rows.Clear();
                da.Fill(dt_databases);

                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES, "Name", "Code", dt_databases, "");
                da.Dispose();
                obj_con.Close() ;
            }
            catch(Exception ex)
            {
            
            }

        }
        private void load_databases(string name)
        {
            try
            {


                SqlConnection obj_con = new SqlConnection();
                obj_con.ConnectionString = connectionstring(false);
                obj_con.Open();



                SqlDataAdapter da = new SqlDataAdapter("select   cast(database_id as nvarchar) as [Code] ,name as [Name]  from sys.databases where database_id > 6 and  name != '" + name + "'", obj_con);
                dt_databases.Rows.Clear();
                da.Fill(dt_databases);

                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES, "Name", "Code", dt_databases, "");
                da.Dispose();
                obj_con.Close();



            }
            catch (Exception ex)
            {

            }

        }
        private void Execute_Query( string query1  , string query2)
        {
            try
            {

                SqlConnection obj_con = new SqlConnection();
                obj_con.ConnectionString = connectionstring(true);
                obj_con.Open();


                SqlCommand obj_cme = new SqlCommand();
                obj_cme.Connection = obj_con;
                obj_cme.CommandType = CommandType.Text;

                for (int x = 0; x < dt_tables.Rows.Count; x++)
                {
                    if (dt_tables.Rows[x]["S"].ToString() == "True")
                    {

                        if (x > 34)
                        {
                            string strstr = "";
                        }
                            string tbl_name = dt_tables.Rows[x]["Names"].ToString();

                        obj_cme.CommandText = query1 +  "["+tbl_name + "]" + query2;
                        obj_cme.ExecuteNonQuery();

                    }
                }
                
                obj_con.Close();


            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);

            }

        }
        private void Insert_Into()
        {
            try
            {

                SqlConnection obj_con = new SqlConnection();
                obj_con.ConnectionString = connectionstring(true);
                obj_con.Open();


                SqlCommand obj_cme = new SqlCommand();
                obj_cme.Connection = obj_con;
                obj_cme.CommandType = CommandType.Text;

                for (int x = 0; x < dt_tables.Rows.Count; x++)
                {
                    if (dt_tables.Rows[x]["S"].ToString() == "True")
                    {

                        string tbl_name = dt_tables.Rows[x]["Names"].ToString();

                        obj_cme.CommandText = "INSERT INTO " + second_db + ".dbo.[" + tbl_name + "] SELECT * FROM "+  LOOK_UP_DATABSES.Text +".dbo.["+tbl_name+"]";
                        string result = "";
                        try
                        {
                            obj_cme.ExecuteNonQuery();
                            result = "Success";
                        }
                        catch (Exception ex)
                        {
                            result = ex.Message;

                        }



                        dt_tables.Rows[x]["Description"] = result;

                    }
                }

                obj_con.Close();


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);

            }

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DAl.SERVERNAME = txt_server.Text.Trim();
            DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim();
            DAl.PASSWORD = txt_password.Text.Trim();
            DAl.USERID = text_id.Text.Trim();


            Tabs.SelectedTabPageIndex = 0;
            load_databases();
          
        }

        DevExpress.XtraTab.XtraTabPage G_obj_tab_page = new DevExpress.XtraTab.XtraTabPage();
        DevExpress.XtraGrid.GridControl G_DATA1 = new GridControl();
        DevExpress.XtraGrid.Views.Grid.GridView GV_DATA1 = new DevExpress.XtraGrid.Views.Grid.GridView();
          DevExpress.XtraTab.XtraTabPage obj_tab_page  = new DevExpress.XtraTab.XtraTabPage();
        DevExpress.XtraGrid.GridControl obj_grd = new GridControl();
         DevExpress.XtraGrid.Views.Grid.GridView obj_Grid_view = new DevExpress.XtraGrid.Views.Grid.GridView();




        void Add_Tabs( string Name , string type)
        {
            obj_tab_page = new DevExpress.XtraTab.XtraTabPage();
            obj_grd = new GridControl();
            obj_Grid_view = new DevExpress.XtraGrid.Views.Grid.GridView();




            obj_tab_page.Name = "tb_" + type + "_" + Name;
            obj_tab_page.Text = Name;
            
           
            xtraTabControl1.TabPages.Add(obj_tab_page);


            
            obj_grd.Name = "G_" + type + "_" + Name;
            obj_grd.Dock = DockStyle.Fill;
            G_DATA1 = obj_grd;
            
            
           
            obj_Grid_view.Name = "GV_" + type + "_" + Name;
            obj_grd.MainView = obj_Grid_view;
            GV_DATA1 = obj_Grid_view;


            obj_tab_page.Controls.Add(obj_grd);

            Generics.cls_Grid_View.GRID_VIEW_APPEARANCE(obj_Grid_view, "I");




           // Add_Grid_Control(Name, type);
        
        }

        void Add_Grid_Control(string Name, string type)
        {

         



        }


        private void frm_Data_View_Load(object sender, EventArgs e)
        {
            dockPanel2.Show();

           // BarLocalizer.Active = new MyBarLocalizer();

            SkinHelper.InitSkinGallery(rbn_gal, true);
          //  SkinHelper.InitSkinPopupMenu(;


            try
            {
                Generic_Function.GRID_VIEW_APPEARANCE(GV_TABLES, "L");
               // Generic_Function.GRID_VIEW_APPEARANCE(GV_DATA, "L");
                GV_TABLES.Focus();
                load_databases();
                DAl.SERVERNAME = txt_server.Text.Trim();
                DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim();
                DAl.PASSWORD = txt_password.Text.Trim();
                DAl.USERID = text_id.Text.Trim();
            }
            catch( Exception ex)
            {
            
            }
        }

        DataTable dt_tables;
        private void load_tables()
        {

            GV_TABLES.FormatConditions.Remove(condition1);
            GV_TABLES.FormatConditions.Remove(condition2);

       //     GV_TABLES.FormatConditions.RemoveAt(0);
         //   GV_TABLES.FormatConditions.RemoveAt(1);


            try
            {

            SqlConnection obj_con = new SqlConnection();

            obj_con.ConnectionString = connectionstring(true);
            obj_con.Open();

                string query = "";



                DevExpress.XtraGrid.GridControl Grid = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView view = new DevExpress.XtraGrid.Views.Grid.GridView();
           


            if (Tabs.SelectedTabPageIndex == 0)
            {

                query = "select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.tables order by name";
                 view = GV_TABLES;
                 Grid = G_TABLES;

            }
            else if (Tabs.SelectedTabPageIndex == 1)
            {


                query = "select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.views";
                view = GV_VIEWS;
                Grid = G_VIEWS;
            }
            else if (Tabs.SelectedTabPageIndex == 2)
            {

                query = "select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.procedures";
                view = GV_PROCEDURES;
                Grid = G_PROCEDURES;
            }



            SqlDataAdapter da = new SqlDataAdapter(query, obj_con);
            dt_tables = new DataTable();
            da.Fill(dt_tables);
            Grid.DataSource = dt_tables;
            Generic_Function.GRID_VIEW_SUMMARY(view, 1);
                //LB_NO_TABLES.Text = dt_tables.Rows.Count.ToString();
            view.Columns["S"].OptionsColumn.ReadOnly = false;
            view.Columns["S"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["S"].Width = 20;
            view.Columns["Names"].OptionsColumn.ReadOnly = true;
            view.Columns["Names"].OptionsColumn.AllowEdit = false;
              //  repositoryItemHyperLinkEdit1
            view.Columns["Description"].ColumnEdit = repositoryItemHyperLinkEdit1;
               
            view.Columns["Description"].Visible = false;
            view.FocusedRowHandle = 0;
            obj_con.Close();
           
                // load_data();
            }
            catch (Exception ex)
            {

            }
            
        }


        DataTable dt_data ;
        private void load_data()
        {
            try
            {


                string table_name = "";

                if (Tabs.SelectedTabPageIndex == 0)
                {

                     table_name = GV_TABLES.GetRowCellValue(GV_TABLES.FocusedRowHandle, "Names").ToString();

                     Add_Tabs(table_name, "T");

                }
                else if (Tabs.SelectedTabPageIndex == 1)
                {


                    table_name = GV_VIEWS.GetRowCellValue(GV_VIEWS.FocusedRowHandle, "Names").ToString();

                    Add_Tabs(table_name, "P");
                }
                else if (Tabs.SelectedTabPageIndex == 2)
                {

                    table_name = GV_PROCEDURES.GetRowCellValue(GV_PROCEDURES.FocusedRowHandle, "Names").ToString();

                    frm_parameters_to obj = new frm_parameters_to(table_name, connectionstring(true));
                    obj.ShowDialog();

                    DataTable dt_stor = new DataTable();
                    dt_stor = frm_parameters_to.dt_return;

                    G_DATA1.DataSource = dt_stor;
                    GV_DATA1.PopulateColumns();
                    Generic_Function.GRID_VIEW_SUMMARY(GV_DATA, 1);
                    //LB_NO_DATA.Text = dt_stor.Rows.Count.ToString();
                    GV_DATA1.BestFitColumns();
                   // GV_DATA.showf
                    return;
                
                }

                SqlConnection obj_con = new SqlConnection();

                obj_con.ConnectionString = connectionstring(true);
                obj_con.Open();




                SqlDataAdapter da = new SqlDataAdapter("select * from [" + table_name + "]" , obj_con);
                dt_data = new DataTable();
                da.Fill(dt_data);
                G_DATA1.DataSource = dt_data;
                GV_DATA1.PopulateColumns();
                Generic_Function.GRID_VIEW_SUMMARY(GV_DATA1, 1);
                   
                // LB_NO_DATA.Text = dt_data.Rows.Count.ToString();
                GV_DATA1.BestFitColumns();
                obj_con.Close();

            }
            catch (Exception ex)
            {

            }

        }

        private void LOOK_UP_DATABSES_EditValueChanged(object sender, EventArgs e)
        {
            Tabs.SelectedTabPageIndex = 0;

            load_tables();
            DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim();
          
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {



            CheckEdit ce = new CheckEdit();
            if(Tabs.SelectedTabPageIndex == 0)
            {
            
                ce = ch_all_tables;
            }
            else if(Tabs.SelectedTabPageIndex == 1)
            {
            
                ce = ch_all_Views;
            }
            else if(Tabs.SelectedTabPageIndex == 2)
            {
            
                ce = ch_all_procedures;
            }

            for (int x = 0; x < dt_tables.Rows.Count; x++ )
            {

                dt_tables.Rows[x]["S"] = ce.Checked;


            }


        }

        private void GV_TABLES_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
           // load_data();
        }

        private void GV_TABLES_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           // load_data();
        }


        static string  second_db = "";

        private void simpleButton2_Click(object sender, EventArgs e)
        {









            if (XtraMessageBox.Show("Are You Sure to Perform This Action !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
            
                return;
            
            }



            if (radioGroup1.SelectedIndex == 0)
            {
                GV_TABLES.Columns["Description"].Visible = false;
                Execute_Query("ALTER TABLE ", " NOCHECK CONSTRAINT aLL");

            }
            else if (radioGroup1.SelectedIndex == 1)
            {
                GV_TABLES.Columns["Description"].Visible = false;
                Execute_Query("ALTER TABLE ", " CHECK CONSTRAINT aLL");

            }
            else if (radioGroup1.SelectedIndex == 2)
            {
                GV_TABLES.Columns["Description"].Visible = false;
                Execute_Query("Delete from ", "");
                load_data();

            }

            else if (radioGroup1.SelectedIndex == 3)
            {
                Tabs.SelectedTabPageIndex = 0;
                frm_sele_db obj = new frm_sele_db(dt_databases);
                obj.ShowDialog();
                second_db = frm_sele_db.db_name;
                GV_TABLES.Columns["Description"].Visible = true;
                splitContainerControl1.Panel1.Width = 300;
                color();
                Insert_Into();
            }

        }

        private void G_VIEWS_Click(object sender, EventArgs e)
        {

        }

        private void Tabs_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
          
            
            
            load_tables();



           


            if (Tabs.SelectedTabPageIndex == 0)
            {

                 ch_all_tables.Checked = true;
            }
            else if (Tabs.SelectedTabPageIndex == 1)
            {

                 ch_all_Views.Checked = true;
            }
            else if (Tabs.SelectedTabPageIndex == 2)
            {

                ch_all_procedures.Checked = true;
            }
        }

        private void G_TABLES_DoubleClick(object sender, EventArgs e)
        {
            load_data();
        }

        private void GV_DATA_FilterEditorCreated(object sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e)
        {
          //  LB_NO_DATA.Text = GV_DATA.RowCount.ToString();  
        }

        private void GV_DATA_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
           // LB_NO_DATA.Text = GV_DATA.RowCount.ToString(); 
        }

        private void GV_DATA_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
          //  LB_NO_DATA.Text = GV_DATA.RowCount.ToString(); 
        }

        private void GV_DATA_RowCountChanged(object sender, EventArgs e)
        {
           // LB_NO_DATA.Text = GV_DATA.RowCount.ToString(); 
        }


            StyleFormatCondition condition1 = new DevExpress.XtraGrid.StyleFormatCondition();
          StyleFormatCondition condition2 = new DevExpress.XtraGrid.StyleFormatCondition();
                 
        private void color()
        {


        
            condition1.Appearance.ForeColor = Color.Green;
            condition1.Appearance.Options.UseForeColor = true;
            condition1.Condition = FormatConditionEnum.Expression;
           // condition1.ApplyToRow = false;
            condition1.Expression = @"[Description] == 'Success'";

            GV_TABLES.FormatConditions.Add(condition1);

             condition2.Appearance.ForeColor = Color.Red;
            condition2.Appearance.Options.UseForeColor = false;
            condition2.Condition = FormatConditionEnum.Expression;
         //   condition1.ApplyToRow = false;
            condition2.Expression = @"[Description] != 'Success'";

            GV_TABLES.FormatConditions.Add(condition2);
        
        }

        private void GV_TABLES_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            



        }

        private void G_TABLES_Click(object sender, EventArgs e)
        {
            
        }

        private void GV_TABLES_Click(object sender, EventArgs e)
        {
            
        }

        private void repositoryItemHyperLinkEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {


          //  string value = GV_TABLES.GetRowCellValue(GV_TABLES.FocusedRowHandle, "Description").ToString() ;
           // XtraMessageBox.Show(value, "Data MS",MessageBoxButtons.OK,MessageBoxIcon.Error);



        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            string value = GV_TABLES.GetRowCellValue(GV_TABLES.FocusedRowHandle, "Description").ToString();
            if(value== "Success")
           XtraMessageBox.Show(value, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                XtraMessageBox.Show(value, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
           // Print_Options obj = new Print_Options(G_DATA);
           // obj.Show();

            DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

            Control obj_control = obj_page.Controls[0];



            printableComponentLink1.Component = (GridControl)obj_control;
            printableComponentLink1.Landscape = checkEdit1.Checked;
            printableComponentLink1.ShowPreview();
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            GV_DATA.OptionsPrint.AutoWidth = checkEdit2.Checked;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


            DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

            Control obj_control = obj_page.Controls[0];


            Export_data obj = new Export_data((GridControl)obj_control);
            obj.ShowDialog();
        
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmBACKUP obj = new frmBACKUP();
            obj.ShowDialog();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            frmRESTO obj = new frmRESTO();
            obj.ShowDialog();
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Print_Options obj = new Print_Options("C");
            obj.ShowDialog();
            Tabs.SelectedTabPageIndex = 0;
            load_databases();
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            printableComponentLink1.Landscape = checkEdit1.Checked;
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure to delete se selected database !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {

                return;

            }
            DAl obj = new DAl();




            int x = LOOK_UP_DATABSES.ItemIndex;
            string db_name = LOOK_UP_DATABSES.Text;
            //dt_databases.Rows.RemoveAt(x);
            load_databases(db_name);


            //string status = obj.ins_del_upd("drop database " + LOOK_UP_DATABSES.Text.Trim());
            ////  DAl.DATABASE = temp_databse;

            //if (status == "ok")
            //    XtraMessageBox.Show(@"Your  has been restored !", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    XtraMessageBox.Show(status, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////Print_Options obj = new Print_Options("DE");
            ////obj.ShowDialog();
            ////Tabs.SelectedTabPageIndex = 0;
            //load_databases();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            Print_Options obj = new Print_Options("DU");
            obj.ShowDialog();
            Tabs.SelectedTabPageIndex = 0;
            load_databases();
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            frm_COPY_DATA obj = new frm_COPY_DATA();
            obj.ShowDialog();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            frm_Reset_identity obj = new frm_Reset_identity();
            obj.ShowDialog();
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frm_GENERATES_SCRIPTS obj = new frm_GENERATES_SCRIPTS();
            obj.ShowDialog();
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            XtraForm2 obj = new XtraForm2();
            obj.ShowDialog();
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {

            DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

            int x =xtraTabControl1.SelectedTabPageIndex;

            xtraTabControl1.TabPages.RemoveAt(x);
            







        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}