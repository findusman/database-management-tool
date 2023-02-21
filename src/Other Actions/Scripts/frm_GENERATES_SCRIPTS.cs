using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
namespace DATA_MS.Other_Actions.Copy
{
    public partial class frm_GENERATES_SCRIPTS : DevExpress.XtraEditors.XtraForm
    {



        public static string database = string.Empty;
        public static string database_2 = string.Empty;
             public static string database_1 = string.Empty;

        DAl obj_Dal = new DAl();


        public frm_GENERATES_SCRIPTS()
        {
            InitializeComponent();
        }



        private void load_databases(char status)
        {
            try
            {




                DataSet ds = obj_Dal.selection("select name as [Names]  from sys.databases");

                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES_1, "Names", "Names", ds.Tables[0], "");
                Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES_2, "Names", "Names", ds.Tables[0], "");

                database_1 = LOOK_UP_DATABSES_1.Text;
                database_2 = LOOK_UP_DATABSES_2.Text;
                
                //  G_DATABASES_1.DataSource = ds;
                // GV_DATABASES_1.PopulateColumns();


                //if (status == '1')
                //{
                //    G_DATABASES_1.DataSource = ds.Tables[0];
                //    G_DATABASES_1.MainView.PopulateColumns();
                //    GV_DATABASES_1.BestFitColumns();

                //    database = get_selected_database(status);
                //}
            }
            catch (Exception ex)
            {

            }

        }
        
        private string get_selected_database(char status)
        {
            try
            {

                if (status == '1')
                {
                    return GV_DATABASES_1.GetRowCellValue(GV_DATABASES_1.FocusedRowHandle, "Names").ToString();
                }


            }
            catch (Exception ex)
            {
                return "";
            }

            return "";
        }

        private void frm_COPY_DATA_Load(object sender, EventArgs e)
        {
            load_databases('1');
          //  load_Grids('1');
          //  load_Grids('2');
        }

              DataSet ds_VIEW = new DataSet();
              DataSet ds_TABLES = new DataSet();
              DataSet ds_PROCEDURES = new DataSet();

              DataSet ds_2 = new DataSet();
              DataSet ds_1 = new DataSet();

        private void load_Grids(char status)
        {

                        ds_TABLES = obj_Dal.selection("    use [" + database_1 + "]     select CAST('False' as Bit)  as [S], name as Names , '' as Description from sys.tables order by name");
                      
                        G_TABLES_1.DataSource = ds_TABLES.Tables[0];
                        G_TABLES_1.MainView.PopulateColumns();
                        GV_TABLES_1.FocusedRowHandle = 0;



                        ds_VIEW = obj_Dal.selection("   use [" + database_1 + "]      select CAST('False' as Bit)  as [S], name as Names , '' as Description from sys.views order by name");
                        G_VIEWS_1.DataSource = ds_VIEW.Tables[0];
                        G_VIEWS_1.MainView.PopulateColumns();
                        GV_VIEWS_1.FocusedRowHandle = 0;


                        ds_PROCEDURES = obj_Dal.selection("     use [" + database_1 + "]     select CAST('False' as Bit)  as [S], name as Names , '' as Description from sys.procedures order by name");
                        G_PROCEDURES_1.DataSource = ds_PROCEDURES.Tables[0];
                        G_PROCEDURES_1.MainView.PopulateColumns();
                        GV_PROCEDURES_1.FocusedRowHandle = 0;





                        GV_TABLES_1.Columns["S"].OptionsColumn.ReadOnly = false;
                        GV_TABLES_1.Columns["S"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        GV_TABLES_1.Columns["S"].Width = 20;

                        GV_TABLES_1.Columns["Names"].OptionsColumn.ReadOnly = true;
                        GV_TABLES_1.Columns["Names"].OptionsColumn.AllowEdit = false;
                        //  repositoryItemHyperLinkEdit1
                        GV_TABLES_1.Columns["Description"].ColumnEdit = repositoryItemHyperLinkEdit1;

                        GV_TABLES_1.Columns["Description"].Visible = false;

                        GV_VIEWS_1.Columns["S"].OptionsColumn.ReadOnly = false;
                        GV_VIEWS_1.Columns["S"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        GV_VIEWS_1.Columns["S"].Width = 20;

                        GV_VIEWS_1.Columns["Names"].OptionsColumn.ReadOnly = true;
                        GV_VIEWS_1.Columns["Names"].OptionsColumn.AllowEdit = false;
                        //  repositoryItemHyperLinkEdit1
                        GV_VIEWS_1.Columns["Description"].ColumnEdit = repositoryItemHyperLinkEdit1;

                        GV_VIEWS_1.Columns["Description"].Visible = false;




                        GV_PROCEDURES_1.Columns["S"].OptionsColumn.ReadOnly = false;
                        GV_PROCEDURES_1.Columns["S"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                        GV_PROCEDURES_1.Columns["S"].Width = 20;

                        GV_PROCEDURES_1.Columns["Names"].OptionsColumn.ReadOnly = true;
                        GV_PROCEDURES_1.Columns["Names"].OptionsColumn.AllowEdit = false;
                        //  repositoryItemHyperLinkEdit1
                        GV_PROCEDURES_1.Columns["Description"].ColumnEdit = repositoryItemHyperLinkEdit1;

                        GV_PROCEDURES_1.Columns["Description"].Visible = false;

                        Generic_Function.GRID_VIEW_SUMMARY(GV_TABLES_1, 1);
                        Generic_Function.GRID_VIEW_SUMMARY(GV_VIEWS_1, 1);
                        Generic_Function.GRID_VIEW_SUMMARY(GV_PROCEDURES_1, 1);
              

        }

        private void load_views_design(char status)
        {
            try
            {

               


            }
            catch (Exception ex)
            {
               
            }

            
        }
        DataSet ds_data_1 = new DataSet();
        DataSet ds_data_2 = new DataSet();
        private void load_data( char status)
        {
            try
            {
               
                  DevExpress.XtraGrid.GridControl Grid = new DevExpress.XtraGrid.GridControl();
                DevExpress.XtraGrid.Views.Grid.GridView view = new DevExpress.XtraGrid.Views.Grid.GridView();
                DevExpress.XtraGrid.Views.Grid.GridView view_data = new DevExpress.XtraGrid.Views.Grid.GridView();





                string table_name = "";

               if(status == '1')
               {
                   view = GV_TABLES_1;
               
                   
                Grid = G_DATA_1;
                view_data = GV_DATA_1;
               }
               if (status == '2')
               {
                   view = GV_TABLES_2;


                   Grid = G_DATA_2;
                   view_data = GV_DATA_2;
               }

               table_name = view.GetRowCellValue(view.FocusedRowHandle, "Names").ToString();

               if (status == '1')
               {
                   ds_data_1 = obj_Dal.selection(" use [" + database_1 + "] select  cast( 1 as Bit ) as S  , * from  [" + table_name + "]");

                   G_DATA_1.DataSource = ds_data_1.Tables[0];
                   G_DATA_1.MainView.PopulateColumns();


                   ds_data_2 = obj_Dal.selection(" use [" + database_2 + "]  select   * from  [" + table_name + "]");
                   if (ds_data_2 != null)
                   {
                       G_DATA_2.DataSource = ds_data_2.Tables[0];
                       G_DATA_2.MainView.PopulateColumns();
                   }
                  
               }
               else
                   if (status == '2')
                   {

                       ds_data_2 = obj_Dal.selection(" use [" + database_2 + "]  select   * from  [" + table_name + "]");
                       G_DATA_2.DataSource = ds_data_2.Tables[0];
                       G_DATA_2.MainView.PopulateColumns();

                       if (ds_data_1 != null)
                       {

                           ds_data_1 = obj_Dal.selection(" use [" + database_1 + "] select  cast( 1 as Bit ) as S  , * from  [" + table_name + "]");

                           G_DATA_1.DataSource = ds_data_1.Tables[0];
                           G_DATA_1.MainView.PopulateColumns();

                       }

                   }

             

               view_data.BestFitColumns();

               GV_DATA_1.BestFitColumns();
               GV_DATA_2.BestFitColumns();
               Generic_Function.GRID_VIEW_SUMMARY(GV_DATA_1, 1);
               Generic_Function.GRID_VIEW_SUMMARY(GV_DATA_2, 0);

               //for (int x = 0; x < view_data.Columns.Count; x++)
               //{

               //    if (x == 0)
               //    {

               //        view_data.Columns[x].OptionsColumn.ReadOnly = false;
               //        view_data.Columns[x].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
               //        view_data.Columns[x].Width = 20;

               //    }
               //    else
               //    {

               //        view_data.Columns[x].OptionsColumn.ReadOnly = true;
               //        // view.Columns[x].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
               //        // view.Columns[x].Width = 20;

               //    }

               //}



            }
            catch (Exception ex)
            {


                XtraMessageBox.Show(ex.Message, "Data MS");


            }
        
        }


        private void GV_DATABASES_1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            database = get_selected_database('1');


        }

        private void Tabs_1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {


            //Tabs_2.SelectedTabPageIndex = Tabs_1.SelectedTabPageIndex;

            //if (Tabs_1.SelectedTabPageIndex != 0 && Tabs_1.SelectedTabPageIndex != 4)
            //{

            //    load_Grids('1');
            //}


            //if (Tabs_1.SelectedTabPageIndex == 1)
            //{

            //    ch_with_data.Visible = true;

            //  //  tb_data_1.PageVisible = true;

            //}
            //else if (Tabs_1.SelectedTabPageIndex != 4)
            //{
            //    ch_with_data.Visible = false;
            //  //  tb_data_1.PageVisible = false;

            //}
        }

        private void LOOK_UP_DATABSES_1_EditValueChanged(object sender, EventArgs e)
        {

            database_1 = LOOK_UP_DATABSES_1.Text;
          //  Tabs_1.SelectedTabPageIndex = 1;
            load_Grids('1');
            ch_all_tables_1.Checked = ch_all_procedures_1.Checked = ch_all_Views_1.Checked = false;
          
        }

        private void LOOK_UP_DATABSES_2_EditValueChanged(object sender, EventArgs e)
        {
            database_2 = LOOK_UP_DATABSES_2.Text;
          //  Tabs_2.SelectedTabPageIndex = 1;
            load_Grids('2');
           
          
        }

        private void GV_TABLES_1_DoubleClick(object sender, EventArgs e)
        {

            load_data('1');
           // Tabs_1.SelectedTabPage = tb_data_1;
        
        }

        private void GV_TABLES_2_DoubleClick(object sender, EventArgs e)
        {
            load_data('2');
          
            Tabs_2.SelectedTabPageIndex = 5;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            load_databases('1');
            load_Grids('1');
            load_Grids('2');
        }


        private void check_all( char status)
        {

            CheckEdit ce = new CheckEdit();
            DataTable dt = new DataTable();

           

                if (Tabs_1.SelectedTabPageIndex == 0)
                {

                    ce = ch_all_tables_1;
                    dt = ds_TABLES.Tables[0];

                }
                if (Tabs_1.SelectedTabPageIndex == 1)
                {

                    ce = ch_all_Views_1;
                    dt =ds_VIEW.Tables[0];

                }
                if (Tabs_1.SelectedTabPageIndex == 2)
                {

                    ce = ch_all_procedures_1;
                    dt =ds_PROCEDURES.Tables[0];

                }
                //if (Tabs_1.SelectedTabPageIndex == 4)
                //{

                //    ce = ch_all_procedures_1;
                //    dt = ds_data_1.Tables[0];

                //}
            
            for (int x = 0; x < dt.Rows.Count; x++)
            {

                dt.Rows[x]["S"] = ce.Checked;


            }
        }



        private void ch_all_procedures_1_CheckedChanged(object sender, EventArgs e)
        {
            check_all('1');
        }



        private string copy_table()
        {

            for (int x = 0; x < ds_1.Tables[0].Rows.Count; x++)
            {
                try
                {
                    string execute = "";



                    if ((Boolean)ds_1.Tables[0].Rows[x]["S"] == true)
                    {
                        GV_TABLES_1.Columns["Description"].Visible = true;
                        


                        string table_name = ds_1.Tables[0].Rows[x]["Names"].ToString();
                        DataSet ds = obj_Dal.selection("    use [" + database_2 + "]     select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.tables where name = '" + table_name + "' order by name");
                        if (ds.Tables[0].Rows.Count == 0)
                        {

                          ds_1.Tables[0].Rows[x]["Description"] =  obj_Dal.ins_del_upd("     use [" + database_2 + "] select * into [" + table_name + "] from [" + database_1 + "].dbo.[" + table_name + "]");

                        }
                        else
                        {
                            if (ch_over_write.Checked)
                            {

                                obj_Dal.ins_del_upd("     use " + database_2 + " drop table [" + table_name + "]");
                                ds_1.Tables[0].Rows[x]["Description"] = obj_Dal.ins_del_upd("     use [" + database_2 + "] select * into [" + table_name + "] from [" + database_1 + "].dbo.[" + table_name + "]");


                            }


                        }

                        if (!ch_with_data.Checked)
                        {

                            obj_Dal.ins_del_upd("     use [" + database_2 + "] delete from [" + table_name + "]");

                        }




                    }

                }
                catch (Exception ex)
                {



                }
            }

            return "ok";
        }

        private string copy_views(string C)
        {
            string state = "";
            for (int x = 0; x < ds_1.Tables[0].Rows.Count; x++)
            {
                try
                {

                    GV_TABLES_1.Columns["Description"].Visible = true;
                        

                    if ((Boolean)ds_1.Tables[0].Rows[x]["S"] == true)
                    {

                        string table_name = ds_1.Tables[0].Rows[x]["Names"].ToString();




                        string query = " select definition " +
                                       " from sys.objects     o " +
                                       " join sys.sql_modules m on m.object_id = o.object_id " +
                                        " where o.object_id = object_id( 'dbo." + table_name + "') " +
                                         " and o.type      = '" + C + "'";

                        DataSet statement = obj_Dal.selection("     use [" + database_1 + "]  " + query);
                        DataSet ds = new DataSet();

                        if (C == "V")
                        {
                            GV_VIEWS_1.Columns["Description"].Visible = true;
                    
                            ds = obj_Dal.selection("    use [" + database_2 + "]     select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.views where name = '" + table_name + "' order by name");
                        
                        }
                        if (C == "P")
                        {
                            GV_PROCEDURES_1.Columns["Description"].Visible = true;
                    
                            ds = obj_Dal.selection("    use [" + database_2 + "]     select CAST('True' as Bit)  as [S], name as Names , '' as Description from sys.procedures where name = '" + table_name + "' order by name");
                        }
                        if (ds.Tables[0].Rows.Count == 0)
                        {


                            string temp = DAl.DATABASE;
                            DAl.DATABASE = database_2;

                            state = obj_Dal.ins_del_upd(statement.Tables[0].Rows[0][0].ToString());
                            ds_1.Tables[0].Rows[x]["Description"] =state;
                            DAl.DATABASE = temp;
                        }
                        else
                        {
                            if (ch_over_write.Checked)
                            {

                                if (C == "V")
                                {

                                    obj_Dal.ins_del_upd("     use " + database_2 + "  drop view [" + table_name + "]");

                                }
                                else
                                {

                                    obj_Dal.ins_del_upd("     use " + database_2 + "  drop procedure [" + table_name + "]");

                                }
                                string temp = DAl.DATABASE;
                                DAl.DATABASE = database_2;

                                state = obj_Dal.ins_del_upd(statement.Tables[0].Rows[0][0].ToString());
                                ds_1.Tables[0].Rows[x]["Description"] = state;
                                DAl.DATABASE = temp;

                            }


                        }

                        //if (!ch_with_data.Checked)
                        //{

                        //    obj_Dal.ins_del_upd("     use " + database_2 + " delete from [" + table_name + "]");

                        //}




                    }

                   
                }
                catch (Exception ex)
                {
                    ds_1.Tables[0].Rows[x]["Description"] =  ex.Message;
                }
            }

            return  "ok";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {



            if (database_1 == database_2)
            { 
            


                 XtraMessageBox.Show("Please don't select the same databases !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                 LOOK_UP_DATABSES_1.Focus();
                 return;


            }






                    if (XtraMessageBox.Show("Are You Sure to Perform This Action !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                          {

                          return;

                            }

                    string execute = "";


          

            if (Tabs_1.SelectedTabPageIndex == 1)
            {
                execute = copy_table();
            }
            else
                if (Tabs_1.SelectedTabPageIndex == 2)
                {
                   execute =   copy_views("V");
                }
                else
                    if (Tabs_1.SelectedTabPageIndex == 3)
                    {
                      execute =   copy_views("P");
                    }
                    else
                        if (Tabs_1.SelectedTabPageIndex == 4)
                        {
                           // execute = copy_data();
                        }


            if (execute == "ok")
            {
                XtraMessageBox.Show("Your Action has been performed!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                load_Grids('2');
            }
            else
            {
               
                XtraMessageBox.Show(execute, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void ch_all_tables_2_CheckedChanged(object sender, EventArgs e)
        {
            check_all('2');
        }




        List<string> LS_Qry = new List<string>();

        private void Tabs_2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {


           






            Tabs_1.SelectedTabPageIndex = Tabs_2.SelectedTabPageIndex;
            if (Tabs_2.SelectedTabPageIndex != 0 && Tabs_2.SelectedTabPageIndex != 4)
            {

                load_Grids('2');
            }

            if (Tabs_2.SelectedTabPageIndex == 1)
            {

                ch_with_data.Visible = true;

                tb_data_2.PageVisible = true;

            }
            else if (Tabs_2.SelectedTabPageIndex != 4)
            {
                ch_with_data.Visible = false;
                tb_data_2.PageVisible = false;

            }

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


            DAl.DATABASE = "Usman";
            // "use  [Usman]  "+ Environment.NewLine +   "GO" +
            string str =     Environment.NewLine+  "CREATE VIEW dbo.View_1 AS SELECT     COA_Customize_Plan_Name, COA_Customize_Id FROM         dbo.COA_Customize" ;
            obj_Dal.ins_del_upd(str);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textEdit1.Text = folderBrowserDialog1.SelectedPath.ToString(); 
        }


        private void Primary_Data_fro_every_file(List<string> list )
        {

          if(ch_nominate_datebase.Checked)
          {

              list.Add("USE [" + LOOK_UP_DATABSES_1.Text + "]");
              list.Add("GO");
          }
          list.Add("--     *****************************************************************************************************************************************************************");
          list.Add("");
          list.Add("");
          list.Add("--                             Creation Date:       "+DateTime.Now.ToString() );
          list.Add("--                             Auther:              Muhammad Usman Raza Attari");
          list.Add("--                             Developed By :       786 Software Technologies");
         
          list.Add("");
          list.Add("");
          list.Add("--     *****************************************************************************************************************************************************************");
          

        }

        char status = 'S';


        private void table_query(List<string> LS ,string tbl_name)
        {

            StreamReader sr = new StreamReader(Application.StartupPath + @"\CQ.txt");

            string str = sr.ReadToEnd();

            DataSet ds = obj_Dal.selection("    use " + LOOK_UP_DATABSES_1.Text + "  " + str + " '" +  tbl_name  +"'");

            if(c_firstDrop.Checked)
                LS.Add("drop table " + tbl_name + Environment.NewLine + "Go");
            
            
            LS.Add("");
            LS.Add("");
            LS.Add("--                                   Table : " + tbl_name);
            LS.Add("");
            LS.Add("");
            if (ds != null)
            {
                
                if (ds.Tables[0].Rows.Count>0)
                {
                    LS.Add(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }
           private void view_pro_query(List<string> LS ,string obj_name, char sta)
        {

          string query = " select definition " +
                                       " from sys.objects     o " +
                                       " join sys.sql_modules m on m.object_id = o.object_id " +
                                        " where o.object_id = object_id( 'dbo." + obj_name + "') " +
                                         " and o.type      = '" + sta + "'";


          DataSet ds = obj_Dal.selection("    use " + LOOK_UP_DATABSES_1.Text + "  " + query);

          if (c_firstDrop.Checked)
          {
              if(sta == 'V')
                  LS.Add("drop view " + obj_name + Environment.NewLine + "Go");
              else
                  LS.Add("drop proceudre " + obj_name + Environment.NewLine + "Go");

          } 
            LS.Add("");
            LS.Add("--                                " + (sta == 'P' ? "Procedure : " : "Views : ") + obj_name);
            LS.Add("");
            LS.Add("");
            if (ds != null)
            {
                
                if (ds.Tables[0].Rows.Count>0)
                {
                    LS.Add(ds.Tables[0].Rows[0][0].ToString());
                }
            }
        }

        private void Query_Creation()
        {

            LS_Qry.Clear();
            Primary_Data_fro_every_file(LS_Qry);


            if (ch_all_tables.Checked)
            {
                for (int x = 0; x < ds_TABLES.Tables[0].Rows.Count; x++)
                {

                    if ((Boolean)ds_TABLES.Tables[0].Rows[x]["S"] == true)
                    {

                        string tbl_name = ds_TABLES.Tables[0].Rows[x]["Names"].ToString();

                        table_query(LS_Qry, tbl_name);

                        if (status == 'S')
                        {

                            create_procedure_layers(  textEdit1.Text + @"\Scripts\Tables\" + tbl_name + ".sql", LS_Qry);


                        }

                    }



                }

                if (status == 'C')
                {

                    create_procedure_layers(textEdit1.Text + @"\Scripts\Tables\Tables.sql", LS_Qry);


                }


            }

            if (ch_all_views.Checked)
            {
                for (int x = 0; x < ds_VIEW.Tables[0].Rows.Count; x++)
                {

                    if ((Boolean)ds_VIEW.Tables[0].Rows[x]["S"] == true)
                    {

                        string tbl_name = ds_VIEW.Tables[0].Rows[x]["Names"].ToString();

                        view_pro_query(LS_Qry, tbl_name, 'V');

                        if (status == 'S')
                        {

                            create_procedure_layers(textEdit1.Text + @"\Scripts\Views\" + tbl_name + ".sql", LS_Qry);


                        }


                    }
                }

                if (status == 'C')
                {

                    create_procedure_layers(textEdit1.Text + @"\Scripts\Views\Views.sql", LS_Qry);


                }
            }

            if (ch_all_procedures.Checked)
            {
                for (int x = 0; x < ds_PROCEDURES.Tables[0].Rows.Count; x++)
                {

                    if ((Boolean)ds_PROCEDURES.Tables[0].Rows[x]["S"] == true)
                    {

                        string tbl_name = ds_PROCEDURES.Tables[0].Rows[x]["Names"].ToString();

                   
                        view_pro_query(LS_Qry, tbl_name, 'P');

                        if (status == 'S')
                        {

                            create_procedure_layers(textEdit1.Text + @"\Scripts\Procedures\" + tbl_name + ".sql", LS_Qry);


                        }

                    }
                }
                if (status == 'C')
                {

                    create_procedure_layers(textEdit1.Text + @"\Scripts\Procedures\Procedures.sql", LS_Qry);


                }
            }



            if (status == 'A')
            {

                create_procedure_layers(textEdit1.Text + @"\Scripts\Query.sql", LS_Qry);


            }



        }


        private void create_procedure_layers(string path, List<string> list)
        {

            StreamWriter sr = File.CreateText(path);

            for (int x = 0; x < list.Count; x++)
            {

                try
                {
                    sr.WriteLine(list[x]);
                    
                }
                catch (Exception eee)
                {
                }

            }
            list.Clear();
            sr.Close();


        }

        private void Generate_Scripts()
        {

            if (textEdit1.Text == "")
            {
                XtraMessageBox.Show("Provide The Saving Path! ", "Data MS");
                return;

            }

            string path = textEdit1.Text + @"\Scripts";

            Directory.CreateDirectory(path);

            if (rg_file_types.EditValue.ToString() != "3" )
            {
                if (ch_all_tables.Checked)
                {
                    Directory.CreateDirectory(path + @"\Tables");
                }
                if (ch_all_views.Checked)
                {
                    Directory.CreateDirectory(path + @"\Views");
                }
                if (ch_all_procedures.Checked)
                {
                    Directory.CreateDirectory(path + @"\Procedures");
                }
            }


            if (rg_file_types.EditValue.ToString() == "1")
            {
                status = 'S';
            }

            else if (rg_file_types.EditValue.ToString() == "2")
            {
                status = 'C';
            }

            else if (rg_file_types.EditValue.ToString() == "3")
            {
                status = 'A';
            }

            Query_Creation();




        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            Generate_Scripts();

            XtraMessageBox.Show("Your Script has been created" , "Data MS");

        }
    }
}