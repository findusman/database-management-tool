using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DATA_MS.Main_Screen
{
    public partial class frm_checkWhereClause : Form
    {
        public frm_checkWhereClause()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
                return;
            start();
        }

        void start()
        {

            List<string> files;
            try
            {
                 files = System.IO.Directory.GetFiles(textEdit1.Text).ToList<string>();
            }
            catch (Exception ex)
            { return; }

            dM_LUBRICANTSDataSet.dt_checkWhereClause.Rows.Clear();

            foreach (string file in files)
            {

                try
                {
                    string content = System.IO.File.ReadAllText(file);
                    int whereCount = content.ToLower().Split(new string[] { "where" }, StringSplitOptions.None).Count();
                    int BRCCount = content.ToLower().Split(new string[] { "@brc_id" }, StringSplitOptions.None).Count();
                    int IsDeletedCount = content.ToLower().Split(new string[] { "is_deleted" }, StringSplitOptions.None).Count();
                    bool status = false;
                    if ((whereCount == BRCCount) && (BRCCount == IsDeletedCount))
                        status = true;
                    dM_LUBRICANTSDataSet.dt_checkWhereClause.Rows.Add(file.Replace(textEdit1.Text + @"\", ""), whereCount, BRCCount, IsDeletedCount);

                }
                catch (Exception exx)
                { 
                
                }

            }

        }


    }
}
