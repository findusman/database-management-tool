using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace DATA_MS
{
    public partial class Print_Options_a : DevExpress.XtraEditors.XtraForm
    {


        DevExpress.XtraGrid.GridControl GC_printing = new DevExpress.XtraGrid.GridControl();


        private string DataBase = string.Empty;

        public string DataBase1
        {
            get { return DataBase; }
            set { DataBase = value; }
        }


        string sta = "";

        public Print_Options_a(string status)
        {
            InitializeComponent();

            sta = status;
           

        }

        public Print_Options_a( DevExpress.XtraGrid.GridControl Grid)
        {
            InitializeComponent();

            printableComponentLink1.Component = Grid;

            // Set the paper orientation to Landscape.
          
          


        }


        private void Print_Options_Load(object sender, EventArgs e)
        {
            if (sta == "DE")
            {

                simpleButton1.Text = "Delete";
                this.Text = "Delete DataBase";
            }
            else if (sta == "D")
            {

                simpleButton1.Text = "Duplicate";
                this.Text = "Duplicate DataBase";
            }
        }


        string Directory_Path(  string File_Name )
        {

            string Main_path = string.Empty;


            string System_Windos_directory_path = Environment.GetEnvironmentVariable("windir", EnvironmentVariableTarget.Machine);

            string System_Drive = System_Windos_directory_path.Substring(0, 1);


            DriveInfo[] drives = DriveInfo.GetDrives();


            foreach (DriveInfo Drive in drives)
            {

                if (Drive.Name.Substring(0, 1) != System_Drive && Drive.TotalFreeSpace > 9073741824)
                {

                    Main_path = Drive.Name.Substring(0, 3) + File_Name;
                    if (!Directory.Exists(Main_path))
                    {
                        Directory.CreateDirectory(Main_path);

                    }
                    return Main_path;
                }

            }


            XtraMessageBox.Show("You don't have any hard drive partision with space 9 GB", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "N";


        }

        void duplicate()
        {

            Restore();
        }

        string Restore()
        {

         //   string BackUp_Status = BackUp();
            string name = text_id.Text;
            string path = BackUp();

            

            if (path != "N")
            {

                try
                {

                    DAl obj = new DAl();




                    DataSet ds = obj.selection("select  name as [Name]  from sys.databases where name = '[" + text_id.Text + "]'");



                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (XtraMessageBox.Show("This database is already exist. Are you want to update the database ?", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {

                            string Is_droped = obj.ins_del_upd("drop database [" + text_id.Text + "]");
                            if (Is_droped != "ok")
                            {

                                XtraMessageBox.Show(Is_droped, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return "N";

                            }

                        }
                        else
                        {
                            return "N";


                        }


                    }
                    string ldf_name = "", mdf_name = "";


                    DataSet ds_logical_name = obj.selection("RESTORE FILELISTONLY FROM DISK = '" + path + "'");


                    if (ds_logical_name.Tables[0].Rows.Count > 0)
                    {
                        mdf_name = ds_logical_name.Tables[0].Rows[0][0].ToString();
                        ldf_name = ds_logical_name.Tables[0].Rows[1][0].ToString();

                        string File_path = "";

                        for (int x = path.Length; x != 0; x--)
                        {

                            if (path[x - 1].ToString() == @"\")
                            {



                                File_path = path.Substring(0, x);

                                break;

                            }



                        }



                        string Query_text = @"RESTORE DATABASE [" + name +
                                             @"] FROM DISK = '" + path + "'" +
                                             @" WITH MOVE '" + mdf_name + "'" + "TO '" + File_path + name + ".mdf '," +
                                               @" MOVE '" + ldf_name + "'" + "TO '" + File_path + name + "_log.ldf'";


                        string Is_Restored = obj.ins_del_upd(Query_text);

                        if (Is_Restored != "ok")
                        {
                            XtraMessageBox.Show(Is_Restored, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return "ok";

                        }
                        else
                        {

                            XtraMessageBox.Show("Your database back up has been restored!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Directory.Delete(path);
                            
                            
                            return "N";
                        }


                    }
                    else
                    {

                        XtraMessageBox.Show("Logical names did't recieve.", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "N";


                    }




                }
                catch (Exception ex)
                {



                }


            


            }



            return "";
        }
        
  

        string BackUp()
        {

            DAl obj = new DAl();


            string File_Name = DateTime.Now.ToString("ddMMyyyyHHmmssFFFF");

            string path = Directory_Path(File_Name);

            if (path != "N")

            {


                string query = @"backup database [" + DataBase1 + @"]  to disk ='" + path + @"\" + File_Name + ".bak" + "' with init,stats=10";
                string status = obj.ins_del_upd(query);

                return path + @"\" + File_Name + ".bak";
            }

            return "N";


        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {

            printableComponentLink1.Landscape = checkEdit1.Checked;

            printableComponentLink1.CreateDocument();
           

            printableComponentLink1.ShowPreview();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}