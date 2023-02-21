using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;


namespace DATA_MS
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm2()
        {
            InitializeComponent();
        }


        

     string imagename;






      DataSet dset;




      private void insert(string str)
      {

          FileStream fs;



          fs = new FileStream(@"I:\1.jpg", FileMode.Open, FileAccess.Read);
          byte[] picbyte = new byte[fs.Length];

          fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));

          fs.Close();


          DAl OBJ_DAL = new DAl();


          string STR = OBJ_DAL.ins_del_upd("INSERT INTO [Image].[dbo].[image] ([image]) VALUES ('" + picbyte + "')");



      }



      public string ImageToBase64(Image image,
System.Drawing.Imaging.ImageFormat format)
      {
          using (MemoryStream ms = new MemoryStream())
          {
              // Convert Image to byte[]
              image.Save(ms, format);
              byte[] imageBytes = ms.ToArray();

              // Convert byte[] to Base64 String
              string base64String = Convert.ToBase64String(imageBytes);
              return base64String;
          }
      }



      private void insert()
      {

          //FileStream fs;



          //fs = new FileStream(@"I:\1.jpg", FileMode.Open, FileAccess.Read);
          //byte[] picbyte = new byte[fs.Length];

          //fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));

          //fs.Close();

          //MemoryStream ms1 = new MemoryStream();

          //pictureEdit1.Image.Save(ms1, ImageFormat.Jpeg);
          //byte[] imageBytes = ms1.ToArray();


       //   string str = ImageToBase64(pictureEdit1.Image, ImageFormat.Jpeg);

          DAl OBJ_DAL = new DAl();


        //  int st = str.Length;


        //  string STR = OBJ_DAL.ins_del_upd("INSERT INTO [image].[dbo].[image] ([image]) VALUES ('" + imageBytes + "')");


          DataSet ds = OBJ_DAL.selection("select * from Image.dbo.[image]");

         // string strstr= ds.Tables[0].Rows[0][0].ToString()

          byte[] imageBytes1 = (byte[])ds.Tables[0].Rows[0][0];




          MemoryStream ms = new MemoryStream(imageBytes1, 0,
         imageBytes1.Length);

          // Convert byte[] to Image
          ms.Write(imageBytes1, 0, imageBytes1.Length);
         // Image image = Image.FromStream(ms, true);

          Image onj_image = new Bitmap(ms);

      }


        private void XtraForm2_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            insert();
        }
    }
}