using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace DATA_MS
    {
   public   class cls_Functions
        {

      static List<string> LS = new List<string>();
       static public string database = "";
      static DAl obj_Dal = new DAl();

      static  public string Get_table_query( string tbl_name )
            {

          LS.Clear();

            StreamReader sr = new StreamReader(Application.StartupPath + @"\CQ.txt");

            string str = sr.ReadToEnd();

            DataSet ds = obj_Dal.selection("    use " + database + "  " + str + " '" + tbl_name + "'");

            LS.Add("");
            LS.Add("");
            LS.Add("--                                   Table : " + tbl_name);
            LS.Add("");
            LS.Add("");
            if ( ds != null )
                {

                if ( ds.Tables [ 0 ].Rows.Count > 0 )
                    {
                    LS.Add(ds.Tables [ 0 ].Rows [ 0 ] [ 0 ].ToString());
                    }
                }

            string data = "";

            foreach ( string line in LS )
                {

                data = data + line + Environment.NewLine;                    

                }

            return data;
          }





    public static  void open_query_in_sql_server(string data)
          {


          string path = Application.StartupPath + @"\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".sql";
          File.WriteAllText(path , data);

          System.Diagnostics.Process.Start(path);



          }



      static  public string Get_view_pro_query(  string obj_name , char sta )
            {

           LS.Clear();

            string query = " select definition " +
                                         " from sys.objects     o " +
                                         " join sys.sql_modules m on m.object_id = o.object_id " +
                                          " where o.object_id = object_id( 'dbo." + obj_name + "') " +
                                           " and o.type      = '" + sta + "'";


            DataSet ds = obj_Dal.selection("    use " + database + "  " + query);

            LS.Add("");
            LS.Add("");
            LS.Add("--                                " + ( sta == 'P' ? "Procedure : " : "Views : " ) + obj_name);
            LS.Add("");
            LS.Add("");
            if ( ds != null )
                {

                if ( ds.Tables [ 0 ].Rows.Count > 0 )
                    {
                    LS.Add(ds.Tables [ 0 ].Rows [ 0 ] [ 0 ].ToString());
                    }
                }


            string data = "";

            foreach ( string line in LS )
                {

                data = data + line + Environment.NewLine;

                }

            return data;


          
          }





       

       
      


        }
    }
