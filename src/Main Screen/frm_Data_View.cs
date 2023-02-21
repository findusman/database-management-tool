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
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Views.Grid;

namespace DATA_MS
{
    public partial class frm_Data_View : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_Data_View()
        {
            InitializeComponent();
        }






        static char selected_tab_type = 'D';




        string connection_string = "";
        private string connectionstring(Boolean database)
        {
            if (database == true)
            {

                connection_string = " Data Source = " + txt_server.Text + "; Database =" + (LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim()) + " ; User Id=" + text_id.Text + ";  Password= " + txt_password.Text + "; ";

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

                DAl obj = new DAl();


                //if (txt_server.Text != ".")
                    DAl.SERVERNAME = txt_server.Text;

                    if (checkBox_isMYSQL.Checked)

                    DAl.DATABASE = "MySQL";
                    else
                        DAl.DATABASE = "master";
                 

                
                    DAl.USERID = text_id.Text;
                    DAl.PASSWORD = txt_password.Text;


                DataSet ds = null;

                if (checkBox_isMYSQL.Checked)

                    ds = obj.selection("SELECT 1 as Code,  SCHEMA_NAME AS `Name` FROM INFORMATION_SCHEMA.SCHEMATA", "", "");
                else
                    ds = obj.selection("select   cast(database_id as nvarchar) as [Code] ,name as [Name]  from sys.databases ", false);



                //SqlConnection obj_con = new SqlConnection();
                //obj_con.ConnectionString = connectionstring(false);
                //obj_con.Open();



                //SqlDataAdapter da = new SqlDataAdapter("select   cast(database_id as nvarchar) as [Code] ,name as [Name]  from sys.databases where database_id > 6", obj_con);
                //dt_databases.Rows.Clear();
                //da.Fill(dt_databases);


                //da.Dispose();
                //obj_con.Close() ;
                //obj_con.Dispose();

                if (checkBox_isMYSQL.Checked)
                {

                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                        ds.Tables[0].Rows[x][0] = x + 1;

                }

                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES, "Name", "Code", ds.Tables[0], "");
                Generic_Function.Grid_lookupedit(repositoryItemLookUpEdit2, "Name", "Code", ds.Tables[0], "");
            }
            catch (Exception ex)
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


                da.Dispose();
                obj_con.Close();
                obj_con.Dispose();
                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES, "Name", "Code", dt_databases, "");


            }
            catch (Exception ex)
            {

            }

        }
        private void Execute_Query(string query1, string query2)
        {
            try
            {


                DAl obj_dal = new DAl();



                for (int x = 0; x < dt_tables.Rows.Count; x++)
                {
                    if (dt_tables.Rows[x]["S"].ToString() == "True")
                    {

                        //if (x > 34)
                        //{
                        //    string strstr = "";
                        //}

                        try
                        {
                            string tbl_name = dt_tables.Rows[x]["Names"].ToString();

                            if (tbl_name == "USER")
                            {
                                string str11 = "";
                            }
                            String main_Query = query1 + "[" + tbl_name + "]" + query2;
                            string status = obj_dal.ins_del_upd(main_Query);

                            if (status != "ok")
                            {

                                string str = "";

                            }
                        }
                        catch (Exception ex)
                        {



                        }
                    }
                }




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

                        obj_cme.CommandText = "INSERT INTO " + second_db + ".dbo.[" + tbl_name + "] SELECT * FROM " + LOOK_UP_DATABSES.Text + ".dbo.[" + tbl_name + "]";
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



            load_databases();

            //f_deleting_data();

        }

        DevExpress.XtraTab.XtraTabPage G_obj_tab_page = new DevExpress.XtraTab.XtraTabPage();
        DevExpress.XtraGrid.GridControl G_DATA1 = new GridControl();
        DevExpress.XtraGrid.Views.Grid.GridView GV_DATA1 = new DevExpress.XtraGrid.Views.Grid.GridView();
        DevExpress.XtraTab.XtraTabPage obj_tab_page = new DevExpress.XtraTab.XtraTabPage();
        DevExpress.XtraGrid.GridControl obj_grd = new GridControl();
        DevExpress.XtraGrid.Views.Grid.GridView obj_Grid_view;

        DevExpress.XtraGrid.Views.Layout.LayoutView obj_layout_view = new DevExpress.XtraGrid.Views.Layout.LayoutView();
        DevExpress.XtraGrid.Views.Card.CardView obj_card_view = new DevExpress.XtraGrid.Views.Card.CardView();
        DevExpress.XtraGrid.Views.Grid.GridView obj_Grid_view_for_view = new DevExpress.XtraGrid.Views.Grid.GridView();



        private void simpleButton_Referesh(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
          //  MessageBox.Show("Text = " + button.Parent.Text + ", Name = " + button.Parent.Name + ", Type = " + button.Parent.GetType());
            XtraTabPage tab = (XtraTabPage)button.Parent;
            var control = tab.Controls;
            GridControl grid = (GridControl)control[1];
            GridView gridView = (GridView)grid.MainView;
            grid.DataSource = null;

           
            DAl obj = new DAl();
            DataSet ds = null;
            string query = "select * from [" + tab.Text + "]";
            var list = grid.Tag.ToString().Split('/');
            string databasename = list[list.Length - 1];
                

            //if (checkBox_isMYSQL.Checked)

            //    ds = obj.selection(query, "", "");
            //else

            ds = obj.selectionWithSeparateDatabase(query, databasename);


            if (ds == null)
            {

                MessageBox.Show("Problem in data loading.");
                return;
            }

            if ( ds.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("Problem in data loading.");
                return;
            }
            grid.DataSource = ds.Tables[0];
            gridView.PopulateColumns();


        }



        void Add_Tabs(string Name, string type, char check_script_or_data, char object_type)
        {


            DevExpress.XtraEditors.SimpleButton simpleButton_referesh;
            simpleButton_referesh = new DevExpress.XtraEditors.SimpleButton();
            simpleButton_referesh.Location = new System.Drawing.Point(1, 1);
            simpleButton_referesh.Name = "simpleButton1";
            simpleButton_referesh.Size = new System.Drawing.Size(15, 15);
            simpleButton_referesh.TabIndex = 0;
            simpleButton_referesh.Text = "R";
           
            simpleButton_referesh.Click += new System.EventHandler(simpleButton_Referesh);




            obj_tab_page = new DevExpress.XtraTab.XtraTabPage();

            obj_tab_page.Name = "tb_" + type + ")" + Name + ")" + check_script_or_data.ToString();
            obj_tab_page.Text = Name;

            //     xtraTabControl1.TabPages.Add(obj_tab_page);


            if (check_script_or_data == 'D')
            {
                xtraTabControl1.TabPages.Add(obj_tab_page);
                obj_grd = new GridControl();

                obj_Grid_view = new DevExpress.XtraGrid.Views.Grid.GridView();

                obj_grd.Name = "G_" + type + "_" + Name + "_" + LOOK_UP_DATABSES.Text.ToString();
                obj_grd.Tag = "G/" + type + "/" + Name + "/" + LOOK_UP_DATABSES.Text.ToString();
                obj_grd.Dock = DockStyle.Fill;
                G_DATA1 = obj_grd;

                obj_Grid_view.Name = "GV_" + type + "_" + Name;
                obj_grd.MainView = obj_Grid_view;
                //obj_grd.Tag = rg_views.EditValue.ToString();
                GV_DATA1 = obj_Grid_view;
                obj_tab_page.Controls.Add(obj_grd);
                obj_tab_page.Controls.Add(simpleButton_referesh);
                simpleButton_referesh.BringToFront();

                Generics.cls_Grid_View.GRID_VIEW_APPEARANCE(obj_Grid_view, "I");


            }
            else
            {


                cls_Functions.database = LOOK_UP_DATABSES.Text;



                RichTextBox obj_rich_text_box = new RichTextBox();
                //  RichTextBox.DefaultFont.FontFamily.Name = "Tahome";   
                obj_rich_text_box.Dock = DockStyle.Fill;
                string data = "";

                if (object_type == 'T')
                {

                    data = cls_Functions.Get_table_query(Name);



                }
                else if (object_type == 'V')
                {
                    data = cls_Functions.Get_view_pro_query(Name, object_type);

                    //  obj_rich_text_box.Text = data;


                }

                else if (object_type == 'P')
                {

                    data = cls_Functions.Get_view_pro_query(Name, object_type);

                    //   obj_rich_text_box.Text = data;



                }


                if (radioGroup5.EditValue.ToString() == "H")
                {
                    xtraTabControl1.TabPages.Add(obj_tab_page);

                    obj_rich_text_box.Text = data;

                    obj_tab_page.Controls.Add(obj_rich_text_box);


                }
                else
                {

                    cls_Functions.open_query_in_sql_server(data);

                }



            }


















            // Generic_Function.GRID_VIEW_SUMMARY(obj_Grid_view, 1);

            xtraTabControl1.SelectedTabPage = obj_tab_page;


            // f_view_options();

            // f_check_data_srce_type();
            //  f_add_seelction_column_for_deletion(true);
            // Add_Grid_Control(Name, type);

        }

        void Add_Grid_Control(string Name, string type)
        {





        }

        void loadServerNames()
        {



            txt_server.Text = System.IO.File.ReadAllText(Generics.cls_Paths.DefaultServers) == "" ? "." : System.IO.File.ReadAllText(Generics.cls_Paths.DefaultServers);

            //string[] listofdtabaes = System.IO.File.ReadAllLines(Generics.cls_Paths.ListOfServers);
            //foreach (string tmp in listofdtabaes)
            //    ComboBoxEdit_listOfDatabases.Properties.Items.Add(tmp);

            //ComboBoxEdit_listOfDatabases.SelectedIndex = 0;

        }


        private void frm_Data_View_Load(object sender, EventArgs e)
        {

            //  txt_server.Text = System.IO.File.ReadAllText(Generics.cls_Paths.DefaultServers).ToString();


            // loadServerNames();
            //  dp_entities.Show();

            // BarLocalizer.Active = new MyBarLocalizer();

            // SkinHelper.InitSkinGallery(rbn_gal, true);
            //  SkinHelper.InitSkinPopupMenu(;


            try
            {

                Generic_Function.GRID_VIEW_APPEARANCE(GV_TABLES, "L");
                // Generic_Function.GRID_VIEW_APPEARANCE(GV_DATA, "L");
                DAl.SERVERNAME = txt_server.Text.Trim();


                if (checkBox_isMYSQL.Checked)

                    DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "mysql" : LOOK_UP_DATABSES.Text.Trim();
             
                else
                    DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
             
                 
                DAl.PASSWORD = txt_password.Text.Trim();
                DAl.USERID = text_id.Text.Trim();
                GV_TABLES.Focus();
                load_databases();

                db = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "" : LOOK_UP_DATABSES.Text.Trim();
                ;
                DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "" : LOOK_UP_DATABSES.Text.Trim();
                ;
                //  dp_entities.Show();

            }
            catch (Exception ex)
            {

            }
        }

        DataTable dt_tables;
        private void load_tables()
        {
            //TextEdit_searchTables.Text = TextEdit_searchViews.Text = TextEdit_searchProcedures.Text = "";

            GV_TABLES.FormatConditions.Remove(condition1);
            GV_TABLES.FormatConditions.Remove(condition2);

            //     GV_TABLES.FormatConditions.RemoveAt(0);
            //   GV_TABLES.FormatConditions.RemoveAt(1);


            try
            {



                //   SqlConnection obj_con = new SqlConnection();

                //  obj_con.ConnectionString = connectionstring(true);
                //   obj_con.Open();

                string query = "";



                DevExpress.XtraGrid.GridControl Grid = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView view = new DevExpress.XtraGrid.Views.Grid.GridView();



                if (Tabs.SelectedTabPageIndex == 0)
                {

                    //query = "select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.tables order by name";

                    if (!checkBox_isMYSQL.Checked)


                        query = "SELECT   CAST('True' as Bit)  as [S], t.name AS Names, c.name AS [Column Names], '' as Description FROM sys.tables AS t INNER JOIN sys.columns c ON t.OBJECT_ID = c.OBJECT_ID order by t.name";

                    else
                        query = "SELECT    (case 1 when 1 then true else false end)  as S,  t.table_name AS 'Names',  t.column_name AS 'Column Names' ,'' as Description from information_schema.COLUMNS t where t.table_schema = '" + DAl.DATABASE + "' order by t.table_name";

                    view = GV_TABLES;
                    Grid = G_TABLES;



                }
                else if (Tabs.SelectedTabPageIndex == 1)
                {


                    query = "SELECT   CAST('True' as Bit)  as [S], t.name AS Names, c.name AS [Column Names], '' as Description FROM sys.views AS t INNER JOIN sys.columns c ON t.OBJECT_ID = c.OBJECT_ID order by t.name ";
                    view = GV_VIEWS;
                    Grid = G_VIEWS;
                }
                else if (Tabs.SelectedTabPageIndex == 2)
                {

                    query = "SELECT   CAST('True' as Bit)  as [S], t.name AS Names, c.name AS [Column Names], '' as Description FROM sys.procedures AS t INNER JOIN sys.parameters c ON t.OBJECT_ID = c.OBJECT_ID order by t.name ";
                    view = GV_PROCEDURES;
                    Grid = G_PROCEDURES;
                }



                // SqlDataAdapter da = new SqlDataAdapter(query, obj_con);
                //dt_tables = new DataTable();
                // da.Fill(dt_tables);

                DAl obj = new DAl();
                DataSet ds = null;

                if (checkBox_isMYSQL.Checked)

                   ds = obj.selection(query, "", "");
                else
                 ds = obj.selection(query);


                dt_tables = ds.Tables[0];
                Grid.DataSource = dt_tables;
                Generic_Function.GRID_VIEW_SUMMARY(view, 1);
                //Grid
                view.Columns["Names"].GroupIndex = 1;
                //LB_NO_TABLES.Text = dt_tables.Rows.Count.ToString();
                view.Columns["S"].OptionsColumn.ReadOnly = false;
                view.Columns["S"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                view.Columns["S"].Width = 20;
                //view.Columns["Names"].OptionsColumn.ReadOnly = true;
                //view.Columns["Names"].OptionsColumn.AllowEdit = false;
                //  repositoryItemHyperLinkEdit1
                view.Columns["Description"].ColumnEdit = repositoryItemHyperLinkEdit1;

                view.Columns["Description"].Visible = false;
                view.FocusedRowHandle = 0;
                // BPosListLayoutItem 
                // obj_con.Close();

                // load_data();
            }
            catch (Exception ex)
            {

            }

        }


        DataTable dt_data;






        void f_show_hide_extra_colunm(Boolean Is_Show)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView GV1 = (DevExpress.XtraGrid.Views.Grid.GridView)G_DATA1.MainView;

            //GV1.Columns[0].Visible = Is_Show;

            //if (Is_Show)
            //{



            //    GV_DATA1.Columns[field_name].Caption = "";
            //    GV_DATA1.Columns[field_name].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            //    GV_DATA1.Columns[field_name].Width = 50;
            //    GV_DATA1.Columns[field_name].OptionsColumn.FixedWidth = true;

            //}

        }



        private void load_data()
        {
            try
            {



                string table_name = "";

                if (Tabs.SelectedTabPageIndex == 0)
                {

                    table_name = GV_TABLES.GetRowCellValue(GV_TABLES.FocusedRowHandle, "Names").ToString();

                    Add_Tabs(table_name, "T", rg_selection_options.EditValue == "D" ? 'D' : 'S', 'T');

                }
                else if (Tabs.SelectedTabPageIndex == 1)
                {


                    table_name = GV_VIEWS.GetRowCellValue(GV_VIEWS.FocusedRowHandle, "Names").ToString();

                    Add_Tabs(table_name, "P", rg_selection_options.EditValue == "D" ? 'D' : 'S', 'V');
                }
                else if (Tabs.SelectedTabPageIndex == 2)
                {

                    if (rg_selection_options.EditValue == "D" && (GV_PROCEDURES.FocusedRowHandle == 0) || (GV_PROCEDURES.FocusedRowHandle > 0))
                    {

                        table_name = GV_PROCEDURES.GetRowCellValue(GV_PROCEDURES.FocusedRowHandle, "Names").ToString();


                        Add_Tabs(table_name, "S", rg_selection_options.EditValue == "D" ? 'D' : 'S', 'P');

                        //frm_parameters_to obj = new frm_parameters_to(table_name, connectionstring(true));
                        //obj.ShowDialog();

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
                    else
                    {


                        table_name = GV_PROCEDURES.GetRowCellValue(GV_PROCEDURES.FocusedRowHandle, "Names").ToString();



                        Add_Tabs(table_name, "S", rg_selection_options.EditValue == "D" ? 'D' : 'S', 'P');



                    }
                }

                //  SqlConnection obj_con = new SqlConnection();

                //obj_con.ConnectionString = connectionstring(true);
                //obj_con.Open();


                string query = "";

                if (checkBox_isMYSQL.Checked)

               query = "select  * from " + table_name ;
       else
                  query = "select  * from [" + table_name + "]";


               




                //SqlDataAdapter da = new SqlDataAdapter(query, obj_con);
                //dt_data = new DataTable();

                DAl obj = new DAl();
                DataSet ds = null;

                if (checkBox_isMYSQL.Checked)

                    ds = obj.selection(query, "", "");
                else
                    ds = obj.selection(query);



                //ds = obj_dal.selection(query);


                dt_data = ds.Tables[0];
                G_DATA1.DataSource = dt_data;
                GV_DATA1.PopulateColumns();
                Generic_Function.GRID_VIEW_SUMMARY(GV_DATA1, 1);

                f_hide_unhide_selected_columnO(true);




                // Generic_Function.GRID_VIEW_SUMMARY(GV_DATA1, 1);

                // LB_NO_DATA.Text = dt_data.Rows.Count.ToString();
                GV_DATA1.BestFitColumns();
                // obj_con.Close();
                // DataTable dt = G_DATA1.DataSource as DataTable;
                // dt.Columns.Add("S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR", typeof(double));

                //G_DATA1.DataSource = dt;





                //  GV1.PopulateColumns();


            }
            catch (Exception ex)
            {

            }

        }




        void f_hide_unhide_selected_columnO(Boolean other)
        {


            try
            {
                DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

                string tab_value = obj_page.Name.ToString();

                string[] values = tab_value.Split('_');

                if (values[1] == "T")
                {
                    bar_btn_maker.Enabled = true;

                    //   groupControl4.Visible = true;

                    if (xtraTabControl1.TabPages.Count <= 0)
                        return;



                    Control obj_control = obj_page.Controls[0];


                    GridControl Grid_Control = (GridControl)obj_control;

                    DevExpress.XtraGrid.Views.Grid.GridView Grid_View = (DevExpress.XtraGrid.Views.Grid.GridView)Grid_Control.MainView;




                    if (rb_delete_options.SelectedIndex == 1)
                        Grid_View.Columns[field_name].Visible = true;
                    else Grid_View.Columns[field_name].Visible = false;



                    if (other)
                    {

                        Grid_View.Columns[field_name].Caption = "S";
                        Grid_View.Columns[field_name].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        Grid_View.Columns[field_name].Width = 50;
                        Grid_View.Columns[field_name].OptionsColumn.FixedWidth = true;

                    }


                    f_add_columns(Grid_View);

                }
                else
                {


                    bar_btn_maker.Enabled = false;
                    //groupControl4.Visible = false;


                }
            }

            catch (Exception ex)
            { }

        }


        public void f_add_columns(DevExpress.XtraGrid.Views.Grid.GridView Grid_View)
        {
            cmp_columns.Properties.Items.Clear();


            for (int x = 0; x < Grid_View.Columns.Count; x++)
            {


                if (Grid_View.Columns[x].FieldName.ToString() != field_name)
                    cmp_columns.Properties.Items.Add(Grid_View.Columns[x].FieldName.ToString());

            }
            cmp_columns.SelectedIndex = 0;
        }


        static string db = string.Empty;
        private void LOOK_UP_DATABSES_EditValueChanged(object sender, EventArgs e)
        {

            TextEdit_searchTables.Text = TextEdit_searchViews.Text = TextEdit_searchProcedures.Text = "";

            Tabs.SelectedTabPageIndex = 0;


            DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
            db = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
            
            load_tables();




            dp_entities.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            dp_databases.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;






        }



        void f_deleting_data()
        {




            DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

            string tab_value = obj_page.Name.ToString();

            string[] values = tab_value.Split('_');

            if (xtraTabControl1.TabPages.Count <= 0)
                return;

            Control obj_control = obj_page.Controls[0];


            GridControl Grid_Control = (GridControl)obj_control;

            DevExpress.XtraGrid.Views.Grid.GridView Grid_View = (DevExpress.XtraGrid.Views.Grid.GridView)Grid_Control.MainView;



            string p_column = cmp_columns.SelectedItem.ToString();

            for (int x = 0; x < Grid_View.RowCount; x++)
            {



                Boolean status = Convert.ToBoolean(Grid_View.GetRowCellValue(x, field_name));

                string value = Grid_View.GetRowCellValue(x, p_column).ToString();
                DAl obj = new DAl();
                if (status)
                {

                    string query = "delete from " + values[2] + " where  cast(  " + p_column + " as nvarchar) = '" + value + "'";
                    string status_ = obj.ins_del_upd(query);
                }


            }



        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {



            CheckEdit ce = new CheckEdit();
            if (Tabs.SelectedTabPageIndex == 0)
            {

                ce = ch_all_tables;
            }
            else if (Tabs.SelectedTabPageIndex == 1)
            {

                ce = ch_all_Views;
            }
            else if (Tabs.SelectedTabPageIndex == 2)
            {

                ce = ch_all_procedures;
            }

            for (int x = 0; x < dt_tables.Rows.Count; x++)
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


        static string second_db = "";


        void Perform_button()
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
                //  load_data();

            }

            else if (radioGroup1.SelectedIndex == 3)
            {
                Tabs.SelectedTabPageIndex = 0;
                frm_sele_db obj = new frm_sele_db(dt_databases);
                obj.ShowDialog();
                second_db = frm_sele_db.db_name;
                GV_TABLES.Columns["Description"].Visible = true;
                //  splitContainerControl1.Panel1.Width = 300;
                color();
                Insert_Into();
            }

        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {








        }

        private void G_VIEWS_Click(object sender, EventArgs e)
        {

        }

        private void Tabs_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {



            load_tables();






            if (Tabs.SelectedTabPageIndex == 0)
            {


                //  f_Type_Changed_options('G' , 'T');
                ch_all_tables.Checked = true;
            }
            else if (Tabs.SelectedTabPageIndex == 1)
            {
                //  f_Type_Changed_options('G' , 'T');
                ch_all_Views.Checked = true;
            }
            else if (Tabs.SelectedTabPageIndex == 2)
            {

                ch_all_procedures.Checked = true;
            }


            search();
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
            if (value == "Success")
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
            string db_name = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
            ;
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

            int x = xtraTabControl1.SelectedTabPageIndex;

            xtraTabControl1.TabPages.RemoveAt(x);








        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dockPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bar_btn_exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bar_btn_calc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void bar_btn_notepad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("osk");
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dp_databases.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
        }

        private void barButtonItem35_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dp_entities.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dp_views_option.Show();
        }

        void f_view_options()
        {


            G_DATA1.Tag = rg_views.EditValue.ToString();


            if (rg_views.EditValue.ToString() == "G")
            {

                obj_Grid_view = new DevExpress.XtraGrid.Views.Grid.GridView();
                Generics.cls_Grid_View.GRID_VIEW_APPEARANCE(obj_Grid_view, "I");
                G_DATA1.MainView = obj_Grid_view;
                obj_Grid_view.PopulateColumns();
                GV_DATA1 = obj_Grid_view;


                obj_Grid_view.OptionsView.ColumnAutoWidth = false;


                //  f_show_hide_extra_colunm(true);


                //obj_Grid_view.Columns[field_name].Caption = "S";
                //obj_Grid_view.Columns[field_name].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                //obj_Grid_view.Columns[field_name].Width = 50;
                //obj_Grid_view.Columns[field_name].OptionsColumn.FixedWidth = true;

                // Generic_Function.GRID_VIEW_SUMMARY(GV_DATA, 1);
                // obj_Grid_view.BestFitColumns();

            }
            if (rg_views.EditValue.ToString() == "L")
            {

                obj_layout_view = new DevExpress.XtraGrid.Views.Layout.LayoutView();

                G_DATA1.MainView = obj_layout_view;
                obj_layout_view.PopulateColumns();


            }
            if (rg_views.EditValue.ToString() == "C")
            {

                obj_card_view = new DevExpress.XtraGrid.Views.Card.CardView();

                G_DATA1.MainView = obj_card_view;
                obj_card_view.PopulateColumns();

            }





        }

        private void rg_views_SelectedIndexChanged(object sender, EventArgs e)
        {

            f_view_options();


        }

        DevExpress.XtraGrid.Columns.GridColumn Col_DEl;
        string field_name = "S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR";
        void f_add_seelction_column_for_deletion(Boolean status)
        {
            DevExpress.XtraGrid.Views.Grid.GridView GV = G_DATA1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;



            if (g_is_type_ok && status)
            {


                if (rb_delete_options.SelectedIndex == 1)
                {




                    rg_views.EditValue = "G";
                    f_view_options();

                    DevExpress.XtraGrid.Views.Grid.GridView GV1 = G_DATA1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;



                    //Col_DEl = new DevExpress.XtraGrid.Columns.GridColumn();

                    //Col_DEl.FieldName = field_name;


                    //GV1.Columns.Add(Col_DEl);



                    DataTable dt = G_DATA1.DataSource as DataTable;
                    dt.Columns.Add("S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR", typeof(double));

                    G_DATA1.DataSource = dt;
                    GV1.PopulateColumns();



                    //GV.Columns["S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR"].OptionsColumn.FixedWidth = true;
                    //GV.Columns["S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR"].Width = 30;
                    //GV.Columns["S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR"].VisibleIndex = 0;
                    //GV.Columns["S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    //GV.Columns["S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR"].Caption = "";


                }
            }
            else
            {
                try
                {
                    // GV.Columns["S!@#$%^&*SSSDDDDFFGGHJJJKIIIIIIUUUUUYYRR"].Visible = false;
                }
                catch (Exception ex)
                {


                }

            }

        }


        void f_check_data_srce_type()
        {


            string G_name = G_DATA1.Name.ToString();

            string[] G_name_s = G_name.Split('_');

            if (G_name_s[1] == "T")
                g_is_type_ok = true;
            else
                g_is_type_ok = false;





        }

        Boolean g_is_type_ok = false;



        void f_Type_Changed_options(char Type, char status)
        {

            selected_tab_type = Type;

            if (status == 'T')
            {

                if (Type == 'D')
                {

                    bar_btn_change_pass.Enabled = true;

                }

                else
                {

                    bar_btn_change_pass.Enabled = false;

                }

            }
            else
            {
                if (Type == 'T')
                {

                    bar_btn_maker.Enabled = true;
                    barButtonItem4.Enabled = true;
                    barButtonItem32.Enabled = true;
                    barButtonItem31.Enabled = true;
                    e.Enabled = true;


                }

                else
                {

                    bar_btn_maker.Enabled = false;
                    barButtonItem4.Enabled = false;
                    barButtonItem32.Enabled = false;
                    barButtonItem31.Enabled = false;
                    e.Enabled = false;

                }

            }

        }





        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

            try
            {



                DevExpress.XtraTab.XtraTabPage obj_page = e.Page;
                string[] str = obj_page.Name.Split('_');
                f_Type_Changed_options(Convert.ToChar(str[3]), 'T');


                //Control obj_control = obj_page.Controls[0];


                //  G_DATA1 = (GridControl)obj_control;

                //  DevExpress.XtraGrid.Views.Grid.GridView Grid_View = (DevExpress.XtraGrid.Views.Grid.GridView)G_DATA1.MainView;


                // GV_DATA1 = Grid_View;

                // f_hide_unhide_selected_columnO(false);

                //   GV_DATA1.BestFitColumns();
                // rg_views.EditValue = G_DATA1.Tag.ToString();




                //  GV_DATA1.Columns[0].Caption = "S";
                // f_view_options();
                //  f_check_data_srce_type();
                //  f_add_seelction_column_for_deletion(true);


            }
            catch (Exception)
            {


            }
        }

        private void bar_btn_rights_allocation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print_Options obj = new Print_Options("I");
            obj.ShowDialog();
            Tabs.SelectedTabPageIndex = 0;
            load_databases();
        }

        private void bar_btn_person_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBACKUP obj = new frmBACKUP();
            obj.ShowDialog();
        }

        private void bar_btn_person_info_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmRESTO obj = new frmRESTO();
            obj.ShowDialog();
            load_databases();
        }

        private void bar_btn_change_pass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                if (xtraTabControl1.TabPages.Count <= 0)
                {

                    XtraMessageBox.Show("First select your Data that will be exported!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

                Control obj_control = obj_page.Controls[1];

                GridControl Gr = (GridControl)obj_control;



                Export_data obj = new Export_data((GridControl)obj_control);
                obj.ShowDialog();
            }
            catch (Exception)
            {


            }
        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_COPY_DATA obj = new frm_COPY_DATA();
            obj.ShowDialog();
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_COPY_DATA obj = new frm_COPY_DATA();
            obj.ShowDialog();
        }

        private void e_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            dp_entities.Show();

            radioGroup1.SelectedIndex = 0;
            //  simpleButton2.PerformClick();
            Perform_button();
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dp_entities.Show();


            radioGroup1.SelectedIndex = 1;
            //simpleButton2.PerformClick();

            Perform_button();
        }

        private void bar_btn_maker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dp_entities.Show();

            radioGroup1.SelectedIndex = 2;
            //simpleButton2.PerformClick();


            Perform_button();
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            dp_entities.Show();
            radioGroup1.SelectedIndex = 3;
            //  simpleButton2.PerformClick();

            Perform_button();
        }

        private void bar_btn_formats_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frm_Reset_identity obj = new frm_Reset_identity();
            obj.ShowDialog();
        }

        private void bar_btn_default_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_GENERATES_SCRIPTS obj = new frm_GENERATES_SCRIPTS();
            obj.ShowDialog();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void radioGroup4_SelectedIndexChanged(object sender, EventArgs e)
        {



            f_hide_unhide_selected_columnO(false);

            //if (rb_delete_options.SelectedIndex == 0)
            //{
            //    f_add_seelction_column_for_deletion(false);
            //    radioGroup1.SelectedIndex = 2;
            //    simpleButton2.PerformClick();
            //}
            //else
            //{

            //    f_add_seelction_column_for_deletion(true);
            //}
        }

        private void bar_btn_supplier_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (LOOK_UP_DATABSES.Text != "Select DataBase")
            {

                Print_Options obj = new Print_Options("D");
                obj.DataBase1 = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
                ;
                obj.ShowDialog();
                load_databases();
            }
            else
            {

                XtraMessageBox.Show("First select your database which will be duplicated!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }
        }

        private void btn_category_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (XtraMessageBox.Show("Are you want to delete the database ?", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {

            }

            db = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
            ;

            load_databases();

            if (LOOK_UP_DATABSES.Text != "Select DataBase")
            {

                DAl.DATABASE = "master";


                DAl obj = new DAl();
                // string status =  obj.ins_del_upd("Use master drop database ["+LOOK_UP_DATABSES.Text+"] " );

                string status = obj.ins_del_upd("drop database [" + db + "]");


                XtraMessageBox.Show(status == "ok" ? "Database has been deleted! " : status, "Data MS", MessageBoxButtons.OK, status == "ok" ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                DAl.DATABASE = LOOK_UP_DATABSES.Text;
                load_databases();
                load_tables();
                return;
                //  DAl.DATABASE = "";
                //string database = LOOK_UP_DATABSES.Text;

                //load_databases(database);

            }
            else
            {

                XtraMessageBox.Show("First select your database which will be duplicated!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }



        }

        private void autoHideContainer1_Click(object sender, EventArgs e)
        {

        }

        private void bar_btn_create_user_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            if (xtraTabControl1.TabPages.Count <= 0)
            {

                XtraMessageBox.Show("First select your Data that will be printed!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

            Control obj_control = obj_page.Controls[1];

            if (selected_tab_type == 'D')
            {




                GridControl Gr = (GridControl)obj_control;



                Print_Options_a obj = new Print_Options_a(Gr);
                obj.ShowDialog();
            }
            else
            {



                RichTextBox RTB = (RichTextBox)obj_control;

                //   RTB.

            }

        }

        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {




        }

        private void barEditItem1_ShowingEditor(object sender, DevExpress.XtraBars.ItemCancelEventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void radioGroup4_SelectedIndexChanged_1(object sender, EventArgs e)
        {


            if (rg_selection_options.EditValue.ToString() == "D")
            {
                radioGroup5.Visible = false;

            }

            else
            {
                radioGroup5.Visible = true;

            }

        }

        private void TextEdit_searchTables_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit_searchProcedures.Text = TextEdit_searchViews.Text = TextEdit_searchTables.Text;

            search();
        }

        void search()
        {
            string data = "";
            bool condition = false;
            if (Tabs.SelectedTabPage == tb_tables)
            {
                data = TextEdit_searchTables.Text;
                condition = CheckEdit_allstrTables.Checked;
            }
            else if (Tabs.SelectedTabPage == tb_views)
            {
                data = TextEdit_searchViews.Text;
                condition = CheckEdit_sllstrViews.Checked;
            }
            else if (Tabs.SelectedTabPage == tb_procedures)
            {
                data = TextEdit_searchProcedures.Text;
                condition = CheckEdit_allstrprocedure.Checked;
            }
            try
            {
                if (condition)
                    dt_tables.DefaultView.RowFilter = "Names   like  '%" + data + "%'";
                else
                    dt_tables.DefaultView.RowFilter = "Names  like '%" + data + "%'";

                //DataView dv;
                //dv = new DataView(dt, "name like '" + t_search.Text + "'%", "name Desc", DataViewRowState.CurrentRows);
                //dgv_tables.DataSource = dv;
            }
            catch (Exception ex)
            { }
        }

        private void TextEdit_searchViews_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit_searchTables.Text = TextEdit_searchProcedures.Text = TextEdit_searchViews.Text;
            search();
        }

        private void CheckEdit_sllstrViews_CheckedChanged(object sender, EventArgs e)
        {
            search();
        }

        private void TextEdit_procedures_EditValueChanged(object sender, EventArgs e)
        {
            TextEdit_searchTables.Text = TextEdit_searchViews.Text = TextEdit_searchProcedures.Text;
            search();
        }

        private void CheckEdit_allstrprocedure_CheckedChanged(object sender, EventArgs e)
        {

            search();
        }

        private void CheckEdit_allstrTables_CheckedChanged(object sender, EventArgs e)
        {
            search();
        }

        private void barEditItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barEditItem2_EditValueChanged(object sender, EventArgs e)
        {
            Tabs.SelectedTabPageIndex = 0;


            DAl.DATABASE = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
            ;
            db = LOOK_UP_DATABSES.Text.Trim() == "Select DataBase" ? "master" : LOOK_UP_DATABSES.Text.Trim();
            ;
            load_tables();




            dp_entities.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            dp_databases.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;


        }

        private void SimpleButton_Add_Click(object sender, EventArgs e)
        {
            if (txt_server.Text != "" || txt_server.Text != ".")
                System.IO.File.WriteAllText(Generics.cls_Paths.DefaultServers, txt_server.Text);
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxEdit_listOfDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_server.Text = ComboBoxEdit_listOfDatabases.EditValue.ToString();
        }

        private void txt_server_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem37_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {

                if (xtraTabControl1.TabPages.Count <= 0)
                {

                    XtraMessageBox.Show("First select your Data that will be printed!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DevExpress.XtraTab.XtraTabPage obj_page = xtraTabControl1.SelectedTabPage;

                Control obj_control = obj_page.Controls[0];


                if (selected_tab_type == 'D')
                {




                    GridControl Gr = (GridControl)obj_control;

                    string[] str = Gr.Name.Split(')');
                    string tbl_name = str[1];
                    string database_name = str[2];

                    DAl obj_dal = new DAl();
                    DataSet ds = new DataSet();
                    string query = "select * from " + database_name + ".dbo." + tbl_name;
                    ds = obj_dal.selection(query);
                    Gr.DataSource = ds.Tables[0];
                    Gr.MainView.PopulateColumns();

                }
            }
            catch (Exception ex)
            {



            }
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            DATA_MS.Main_Screen.frm_checkWhereClause obj = new Main_Screen.frm_checkWhereClause();
            obj.Show();

        }

        private void checkBox_isMYSQL_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_isMYSQL.Checked)
            {

                txt_server.Text = "localhost";
                txt_password.Text = "";
                text_id.Text = "root";
                
 
            }
            else
            {

                txt_server.Text = ".";
                txt_password.Text = "sa";
                text_id.Text = "root";
                

            }


        }

        private void autoHideContainer1_Click_1(object sender, EventArgs e)
        {

        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSQLStructure obj = new frmSQLStructure();
            obj.Show();
        }
    }
}