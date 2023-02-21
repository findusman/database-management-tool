using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.IO;
using System.Data.SqlClient;
using System.Data;

using Microsoft.SqlServer;
//using System.Object ;
 using  Microsoft.SqlServer.Server;
//using Microsoft.SqlServer.Management;
//using Microsoft.SqlServer.Management.Common;
//  using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Server..Smo;






namespace DATA_MS
{
    public partial class frmRESTO : DevExpress.XtraEditors.XtraForm
    {
         private static string code = string.Empty;
        private string[] cols_values;

        static private string Status = "I";
        string ExeState = "";
        static string select_value = string.Empty;


        private void Referesh()
        {

            Status = "I";


        }

        public frmRESTO()
        {
            InitializeComponent();
        }

        private void frmBANK_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aiaDataSet2.COA' table. You can move, or remove it, as needed.
          //  this.cOATableAdapter.Fill(this.aiaDataSet2.COA);
           

        }

     
     


        public void RestoreDatabase(String databaseName, String backUpFile, String serverName, String userName, String password)
        {

            
            //ServerConnection connection = new ServerConnection(serverName, userName, password);
            //Server sqlServer = new Server(connection);
            //Restore rstDatabase = new Restore();
            //rstDatabase.Action = RestoreActionType.Database;
            //rstDatabase.Database = databaseName;
            //BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
            //rstDatabase.Devices.Add(bkpDevice);
            //rstDatabase.ReplaceDatabase = true;
            //rstDatabase.SqlRestore(sqlServer);
        }

        private void buttonDELETE_Click(object sender, EventArgs e)
        {

            string name =  text_id.Text;
            string path = textBANK_ACCOUNT.Text;






            //if (XtraMessageBox.Show("Are sure to Save The Back Upwith Name '"+name+"' At: " + path, cls_global_veriables.company_name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            //{

            //    return;

            //}
            //if (textBANK_NAME.Text == "")
            //{

            //    cls_generic_Functions.MsgBox("Please Provide The Back Up Name !", cls_global_veriables.company_name, 'I');
            //    return;
            //}

            if (textBANK_ACCOUNT.Text == "")
            {

                XtraMessageBox.Show("Please Provide the back up saving path !", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (checkEdit1.Checked && text_id.Text == "")
            {
                XtraMessageBox.Show("Please Provide your new database name !", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
         
            }






          //  RestoreDatabase(DAl.DATABASE , path , DAl.SERVERNAME,DAl.USERID,DAl.PASSWORD );
           



            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            //if (Directory.Exists(path))
            //{
            //    if (File.Exists(path +@"\" + name +".bak"))
            //    {

            //        if (XtraMessageBox.Show(@"Do you want to replace it?", cls_global_veriables.company_name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            File.Delete(path +@"\" + name +".bak");
            //        }
            //        else
            //            bBackUpStatus = false;
                
            //    }
            //}
            //else
            //    Directory.CreateDirectory(path);

            //if (bBackUpStatus)
            //{


            try
            {
                
                DAl obj = new DAl();




                DataSet ds = obj.selection("select  name as [Name]  from sys.databases where name = '[" + text_id.Text + "]'");



                if (ds.Tables[0].Rows.Count > 0)
                {

                  if(XtraMessageBox.Show("This database is already exist. Are you want to update the database ?", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                  {

                      string Is_droped = obj.ins_del_upd("drop database [" + text_id.Text + "]" );
                      if (Is_droped != "ok")
                      {

                          XtraMessageBox.Show(Is_droped, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          return;
         
                      }
                    
                  }
                    else
                    {
                        return;


                    }

                   
                }
                          string ldf_name = "", mdf_name = "" ;


                          DataSet ds_logical_name = obj.selection("RESTORE FILELISTONLY FROM DISK = '" + path + "'");


                          if (ds_logical_name.Tables[0].Rows.Count > 0)
                          {
                              mdf_name = ds_logical_name.Tables[0].Rows[0][0].ToString();
                              ldf_name = ds_logical_name.Tables[0].Rows[1][0].ToString();

                              string File_path = "";

                              for(int x = path.Length ; x!=0 ;x--)
                              {

                                  if( path[x-1].ToString() == @"\")
                                  {



                                       File_path = path.Substring(0, x);

                                       break;

                                  }

                                    

                              }



                              string Query_text = @"RESTORE DATABASE ["  + name +
                                                   @"] FROM DISK = '" + path + "'" +
                                                   @" WITH MOVE '" + mdf_name + "'" + "TO '" + File_path + name + ".mdf '," +
                                                     @" MOVE '" + ldf_name + "'" + "TO '" + File_path + name + "_log.ldf'";


                              string Is_Restored = obj.ins_del_upd(Query_text);

                              if (Is_Restored != "ok")
                              {
                                  XtraMessageBox.Show(Is_Restored, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                  return;

                              }
                              else 
                              {

                                      XtraMessageBox.Show("Your database back up has been restored!", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      return;
                              }


                          }
                          else
                          {

                              XtraMessageBox.Show("Logical names did't recieve.", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                              return;
         

                          }




                      

                 



                //string temp_databse = DAl.DATABASE;
                //string query = "";
              
                //if (checkEdit1.Checked && text_id.Text != "")
                //{
                //    DAl.DATABASE = text_id.Text;
                //    query = @" create database " + DAl.DATABASE + " use " + DAl.DATABASE + " restore database " + DAl.DATABASE + " from disk = '" + path + "'    WITH REPLACE";

                //}
                //else 
                //{

                //     query = @"restore database " + DAl.DATABASE + " from disk = '" + path + "'    WITH REPLACE";

                //}







                //string status = obj.ins_del_upd(query);
                //DAl.DATABASE  = temp_databse;

                //if (status == "ok")
                //    XtraMessageBox.Show(@"Your back has been restored !", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    XtraMessageBox.Show(status, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
              

            
            }
            catch (Exception ex)
            {

            
            
            }





            //if (Status == "I")
            //{
            //    cls_generic_Functions.MsgBox("Please First Select The Bank !    ", cls_global_veriables.company_name, 'D');
            //    return;

            //}

            //else if (Status == "U")
            //{

            //    if (XtraMessageBox.Show(cls_global_veriables.question_delete_msg, cls_global_veriables.company_name, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            //    {

            //        return;

            //    }

            //    obj_bll_BANK.BANK_CODE = textBANK_CODE.Text;
            //    obj_bll_BANK.CMP_CODE = cls_global_veriables.company_code;
            //    obj_bll_BANK.STATUS = 'D';

            //    ExeState = obj_bll_BANK.deletion();

            //    if (ExeState == "ok")
            //    {

            //        cls_generic_Functions.Refresh(this);
            //        Status = "I";

            //        cls_generic_Functions.MsgBox(cls_global_veriables.delete_msg, cls_global_veriables.company_name, 'D');

            //    }

            //    else
            //    {


            //        cls_generic_Functions.MsgBox(ExeState, cls_global_veriables.company_name, 'D');



            //    }



            //}
        }

        private void buttonREFERESH_Click(object sender, EventArgs e)
        {
            Referesh();
        }

        private void buttonEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     

        private void simpleButton5_Click(object sender, EventArgs e)
        {



            try
            {
                


                filedialog.ShowDialog();

                filedialog.Filter = "BackUp|*.bak";
                filedialog.FilterIndex = 1;


                if (filedialog.FileName != "" || filedialog.FileName != null)
                {
                    textBANK_ACCOUNT.Text = filedialog.FileName;

                }
                //  pictureCUS_IMAGE.Properties.ZoomPercent = 25;
                // pictureCUS_IMAGE.Properties.SizeMode = PictureSizeMode.Zoom;
            }
            catch (Exception ee)
            {

            }
           
            














            //cls_dataset.fBANK_dataset("0", "no", 'A', false);

            //frlLOOKUP obj_lookup = new frlLOOKUP(cls_dataset.gBANK_dataset, 4, true);
            //obj_lookup.ShowDialog();

            //string value = frlLOOKUP.value;

            //if (value != "")
            //{

            //    cols_values = value.Split('|');
            //    selection(cols_values[1], 'V');
            //}
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            text_id.Visible = checkEdit1.Checked;
        }

        private void textBANK_ACCOUNT_EditValueChanged(object sender, EventArgs e)
        {

        }
        //private void selection(string id, char statuss)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {

        //        // cls_dataset.fPERSON_dataset(id, statuss, true);
        //        //   cls_TBL_PERSON obj_bll_person = new cls_TBL_PERSON();
        //        obj_bll_BANK.CMP_CODE = cls_global_veriables.company_code;
        //        obj_bll_BANK.STATUS = statuss;
        //        obj_bll_BANK.BANK_CODE = id;
        //        obj_bll_BANK.gproperty_allocatoin = true;

        //        ds = obj_bll_BANK.selection();

        //        if (ds == null)
        //        {
        //            Refresh();
        //            return;
        //        }
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {


        //            values_setting();


        //            Status = "U";

        //        }
        //        else
        //        {
        //            Referesh();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Referesh();
        //        return;

        //    }
        //}

    
    }
}