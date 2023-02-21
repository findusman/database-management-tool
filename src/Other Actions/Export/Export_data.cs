using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.IO;
using System.Diagnostics;

namespace DATA_MS
{
    public partial class Export_data : DevExpress.XtraEditors.XtraForm
    {


        GridControl Grid = new GridControl();



        public Export_data(GridControl Grid_Control)
        {
            InitializeComponent();

            Grid = Grid_Control;

        }

        private void Export_data_Load(object sender, EventArgs e)
        {
           // cls_generic_Functions.Show_tooltip(this, e);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textpath.Text = folderBrowserDialog1.SelectedPath.ToString();
                
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

            try
            {
                if (textfilename.Text == "")
                {

                    XtraMessageBox.Show("Please Provide File Name !", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (textpath.Text == "")
                {

                    XtraMessageBox.Show("Please Provide File Saving path !", "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }




                string file = textpath.Text + @"\" + textfilename.Text;


                if (cmb_expot_to.SelectedIndex == 0)
                {
                    Grid.ExportToXlsx(file + ".xlsx");

                    file = file + ".xlsx";


                }
                else if (cmb_expot_to.SelectedIndex == 1)
                {

                    Grid.ExportToXls(file + ".xls");
                    file = file + ".xls";
                }
                else if (cmb_expot_to.SelectedIndex == 2)
                {

                    Grid.ExportToText(file + ".txt");
                    file = file + ".txt";
                }
                else if (cmb_expot_to.SelectedIndex == 3)
                {

                    Grid.ExportToHtml(file + ".html");
                    file = file + ".html";
                }
                else if (cmb_expot_to.SelectedIndex == 4)
                {

                    Grid.ExportToPdf(file + ".pdf");
                    file = file + ".pdf";
                }
                else if (cmb_expot_to.SelectedIndex == 5)
                {

                    Grid.ExportToRtf(file + ".Rtf");
                    file = file + ".Rtf";
                }
                else if (cmb_expot_to.SelectedIndex == 6)
                {

                    Grid.ExportToXlsx(file + ".csv");
                    file = file + ".csv";
                }



                if (XtraMessageBox.Show("Are you want to open the file !  ", "Data MS", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process proc = new Process();
                    proc.StartInfo = new ProcessStartInfo(file, "");
                    proc.Start();
                    file = "";
                }
                file = "";

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message, "Data MS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            
            }





        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {


            textfilename.Text = "";
            textpath.Text = "";
            cmb_expot_to.SelectedIndex = 0;



        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Export_data_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Export_data_KeyDown(object sender, KeyEventArgs e)
        {
           // cls_generic_Functions.Shotcut(this, e);
        }
    }
}