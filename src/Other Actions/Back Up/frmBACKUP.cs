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

namespace DATA_MS
{
    public partial class frmBACKUP : DevExpress.XtraEditors.XtraForm
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

        public frmBACKUP()
        {
            InitializeComponent();
        }

        private void frmBANK_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'aiaDataSet2.COA' table. You can move, or remove it, as needed.
          //  this.cOATableAdapter.Fill(this.aiaDataSet2.COA);
           

        }

        

       
     
       

        private void buttonDELETE_Click(object sender, EventArgs e)
        {

            string name = textBANK_NAME.Text;
            string path = textBANK_ACCOUNT.Text;

            if (XtraMessageBox.Show("Are sure to Save The Back Up with Name '"+name+"' At: " + path, "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {

                return;

            }
            if (textBANK_NAME.Text == "")
            {

               // cls_generic_Functions.MsgBox("Please Provide The Back Up Name !", cls_global_veriables.company_name, 'I');
            XtraMessageBox.Show("Please Provide The Back Up Name !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Error) ;
                return;
            }

            if (textBANK_ACCOUNT.Text == "")
            {

              //  cls_generic_Functions.MsgBox("Please Provide The Back Up Saving Path !", cls_global_veriables.company_name, 'I');
                XtraMessageBox.Show("Please Provide The Back Up Saving Path !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Error); 
                return;
            }





            for (int x = 0; x < textBANK_NAME.Text.Length; x++)
            {

                if (textBANK_NAME.Text[x].ToString() == @"\")
                {
                  //  cls_generic_Functions.MsgBox(@"Your physical Path Contains \ Charater that's not allowed !", cls_global_veriables.company_name, 'I');
                    XtraMessageBox.Show(@"Your physical Path Contains \ Charater that's not allowed !", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Error); 
           
                  //  cls_global_veriables.MessgBox_Hard_Code("Your physical Path Contains '\' Charater that's not allowed !", "D_E");

                    return;

                }


            }












            bool bBackUpStatus = true;

            Cursor.Current = Cursors.WaitCursor;

            if (Directory.Exists(path))
            {
                if (File.Exists(path +@"\" + name +".bak"))
                {

                    if (XtraMessageBox.Show(@"A back up is already exist. Do you want to replace it ?", "Data MS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(path + @"\" + name + ".bak");
                    }
                    else
                        return;
                
                }
            }
            else
                Directory.CreateDirectory(path);

            if (bBackUpStatus)
            {

                ////Connect to DB
                //SqlConnection connect;
                //string con = "Data Source=" + DAl.SERVERNAME + "; Database=" + DAl.DATABASE + "; User Id=" + DAl.USERID + "; Password=" + DAl.PASSWORD + ";";
                //connect = new SqlConnection(con);
                //connect.Open();
                ////----------------------------------------------------------------------------------------------------

                ////Execute SQL---------------
                //SqlCommand command;
                //command = new SqlCommand(@"backup database " + DAl.DATABASE + @"  to disk ='" + path + @"\" + name + ".bak" + "' with init,stats=10", connect);
                //command.ExecuteNonQuery();
                ////-------------------------------------------------------------------------------------------------------------------------------

                //connect.Close();

                DAl obj = new DAl();


                string status = obj.ins_del_upd(@"backup database [" + DAl.DATABASE + @"]  to disk ='" + path + @"\" + name + ".bak" + "' with init,stats=10");


                if (status == "ok")
                {
                    XtraMessageBox.Show(@"Your DataBase Back Up With Name '" + name + "' Has Been Saved to: " + path, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBANK_ACCOUNT.Text = string.Empty;
                    textBANK_NAME.Text = string.Empty;
                }
                else

                    XtraMessageBox.Show(status, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
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
            


            folderBrowserDialog1.ShowDialog();
            textBANK_ACCOUNT.Text = folderBrowserDialog1.SelectedPath.ToString();

            textBANK_ACCOUNT.ToolTip = folderBrowserDialog1.SelectedPath.ToString();














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

        private void textBANK_CODE_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBANK_ACCOUNT_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}