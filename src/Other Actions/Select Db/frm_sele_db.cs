using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DATA_MS
{
    public partial class frm_sele_db : DevExpress.XtraEditors.XtraForm
    {
        public frm_sele_db( DataTable lc)
        {
            InitializeComponent();


            Generic_Function.Grid_lookupedit(LOOK_UP_DATABSES, "Name", "Code", lc, "");
            LOOK_UP_DATABSES.ItemIndex = 0;
            // = lc;
        }



        static public string db_name = "";
        private void frm_sele_db_Load(object sender, EventArgs e)
        {

            


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            db_name = LOOK_UP_DATABSES.Text;
            this.Close();
        }
    }
}