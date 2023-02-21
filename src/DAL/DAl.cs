using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using System.ComponentModel;
using MySql.Data.MySqlClient;


namespace DATA_MS
{
    public class DAl
    {


        //public   static string SERVERNAME = "localhost";
        ////public static string SERVERNAME2 = "AATER-PC";
        //public static string DATABASE = "PAK_ASIA";

        //public static string USERID = "sa";

        //public static string PASSWORD = "123";

        public static string SERVERNAME;
        //public static string SERVERNAME2 = "AATER-PC";
        public static string DATABASE;

        public static string USERID;

        public static string PASSWORD;

        // public  string connectionstring = "Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";

        public static string connectionstring = @"Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";


        SqlConnection obj_con;//= new SqlConnection();
        SqlTransaction obj_trn;
        SqlCommand obj_cmd;
        DataSet ds = null;



        public void transaction()
        {
            // obj_trn = new SqlTransaction();

        }


        public string open_connection()
        {

            if (USERID == "" || PASSWORD == "")

                connectionstring = @"Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; Integrated Security=True;";
            else

                connectionstring = "Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";
            //  connectionstring = "Data Source=" + SERVERNAME + "; Database = master; User Id=" + USERID + "; Password=" + PASSWORD + ";";

            try
            {
                // obj_con = new SqlConnection();
                obj_con = new SqlConnection();
                obj_con.ConnectionString = connectionstring;
                obj_con.Open();

            }
            catch (Exception e)
            {
                obj_con.Close();
                obj_con.Dispose();
                return e.Message;

            }


            return "ok";

        }
        public string open_connection(Boolean status)
        {
            // connectionstring = "Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";

            try
            {
                // obj_con = new SqlConnection();
                obj_con = new SqlConnection();
                obj_con.ConnectionString = f_connectionstring(false);
                obj_con.Open();

            }
            catch (Exception e)
            {
                obj_con.Close();
                obj_con.Dispose();
                return e.Message;

            }


            return "ok";

        }

        public string closeconnection()
        {

            try
            {

                obj_trn.Commit();
            }

            catch (Exception e)
            {
                // obj_trn.Rollback();
                return e.Message;

            }

            try
            {

                obj_con.Close();
                obj_con.Dispose();

            }

            catch (Exception e)
            {

                return e.Message;

            }

            return "ok";

        }




        public string ins_del_upd(string query)
        {
            obj_cmd = new SqlCommand();
            //obj_cmd.CommandType = CommandType.Text;
            //obj_cmd.CommandText = "insert into tabl values ( 'usman' , 'usman' , 'usman' )";
            //obj_cmd.ExecuteNonQuery();


            try
            {
                string state = open_connection();
            }
            catch (Exception eee)
            {

                obj_con.Close();
                return eee.Message;
            }
            // transaction();
            if (obj_con.State == ConnectionState.Closed || obj_con.State == ConnectionState.Broken)
            {

                return "Error in connecting database.";

            }


            try
            {

                obj_cmd.Connection = obj_con;

            }
            catch (Exception e)
            {


                obj_con.Close();
                return e.Message;


            }




            obj_cmd.CommandType = CommandType.Text;
            obj_cmd.CommandText = query;
            //  obj_cmd.Parameters.Clear();

            obj_cmd.CommandTimeout = 0;


            //for (int x = 0; x < sql_param.Length; x++)
            //{

            //    obj_cmd.Parameters.Add(sql_param[x]);

            //}



            try
            {

                obj_cmd.ExecuteNonQuery();

            }
            catch (Exception eee)
            {

                obj_con.Close();
                return eee.Message;
            }



            try
            {
                closeconnection();
                // obj_trn.Commit();

            }
            catch (Exception eee)
            {

                obj_con.Close();
                return eee.Message;
            }
            return "ok";
        }
        public string ins_del_upd(string query, Boolean status)
        {
            obj_cmd = new SqlCommand();
            //obj_cmd.CommandType = CommandType.Text;
            //obj_cmd.CommandText = "insert into tabl values ( 'usman' , 'usman' , 'usman' )";
            //obj_cmd.ExecuteNonQuery();


            try
            {
                string state = open_connection(false);
            }
            catch (Exception eee)
            {

                obj_con.Close();
                return eee.Message;
            }
            // transaction();
            if (obj_con.State == ConnectionState.Closed || obj_con.State == ConnectionState.Broken)
            {

                return "Error in connecting database.";

            }


            try
            {

                obj_cmd.Connection = obj_con;

            }
            catch (Exception e)
            {


                obj_con.Close();
                return e.Message;


            }





            obj_cmd.CommandType = CommandType.Text;
            obj_cmd.CommandText = query;
            //  obj_cmd.Parameters.Clear();




            //for (int x = 0; x < sql_param.Length; x++)
            //{

            //    obj_cmd.Parameters.Add(sql_param[x]);

            //}



            try
            {

                obj_cmd.ExecuteNonQuery();

            }
            catch (Exception eee)
            {

                obj_con.Close();
                return eee.Message;
            }



            try
            {
                closeconnection();
                // obj_trn.Commit();

            }
            catch (Exception eee)
            {

                obj_con.Close();
                return eee.Message;
            }
            return "ok";
        }

        public string ins_del_upd(string storeprocedure_deletion, string storeprocedure_main, string storeprocedure_defination, SqlParameter[] sql_param_deletion, SqlParameter[] sql_param_main, SqlParameter[,] sql_param_defination, Boolean single_array_deletion, Boolean single_array, Boolean double_array, int cols, int rows)
        {
            obj_cmd = new SqlCommand();
            try
            {
                string state = open_connection();
            }
            catch (Exception eee)
            {
                obj_trn.Rollback();
                obj_con.Close();
                return eee.Message;
            }
            // transaction();
            if (obj_con.State == ConnectionState.Closed || obj_con.State == ConnectionState.Broken)
            {

                return "Error in connecting database.";

            }


            try
            {

                obj_cmd.Connection = obj_con;

            }
            catch (Exception e)
            {


                obj_con.Close();
                return e.Message;


            }

            try
            {

                obj_cmd.Transaction = obj_trn;


            }
            catch (Exception ee)
            {
                obj_trn.Rollback();
                return ee.Message;
            }
            obj_cmd.CommandType = CommandType.StoredProcedure;



            if (single_array_deletion)
            {
                obj_cmd.Parameters.Clear();
                obj_cmd.CommandText = storeprocedure_deletion;


                for (int x = 0; x < sql_param_deletion.Length; x++)
                {

                    obj_cmd.Parameters.Add(sql_param_deletion[x]);

                }



                try
                {

                    obj_cmd.ExecuteNonQuery();

                }
                catch (Exception eee)
                {
                    obj_trn.Rollback();
                    obj_con.Close();
                    return eee.Message;
                }


            }







            if (single_array)
            {
                obj_cmd.Parameters.Clear();

                obj_cmd.CommandText = storeprocedure_main;


                for (int x = 0; x < sql_param_main.Length; x++)
                {

                    obj_cmd.Parameters.Add(sql_param_main[x]);

                }



                try
                {

                    obj_cmd.ExecuteNonQuery();

                }
                catch (Exception eee)
                {
                    obj_trn.Rollback();
                    obj_con.Close();
                    return eee.Message;
                }


            }







            if (double_array)
            {

                obj_cmd.Parameters.Clear();
                obj_cmd.CommandText = storeprocedure_defination;


                for (int y = 0; y < rows; y++)
                {
                    obj_cmd.Parameters.Clear();

                    for (int x = 0; x < cols; x++)
                    {

                        obj_cmd.Parameters.Add(sql_param_defination[y, x]);

                    }



                    try
                    {

                        obj_cmd.ExecuteNonQuery();

                    }
                    catch (Exception eee)
                    {
                        obj_trn.Rollback();
                        obj_con.Close();
                        return eee.Message;
                    }

                }




            }





            try
            {
                closeconnection();
                // obj_trn.Commit();

            }
            catch (Exception eee)
            {
                obj_trn.Rollback();
                obj_con.Close();
                return eee.Message;
            }
            return "ok";
        }

        public DataSet selection(string query)
        {

            SqlCommand obj_cmd = new SqlCommand();

            //obj_cmd.Connection = obj_con;
            //obj_cmd.CommandType = CommandType.StoredProcedure;
            //obj_cmd.CommandText = storeprocedure;


            //for (int x = 0; x < sql_param.Length; x++)
            //{

            //    obj_cmd.Parameters.Add(sql_param[x]);

            //}
            //open_connection();
            try
            {
                string state = open_connection();
            }
            catch (Exception eee)
            {
                obj_trn.Rollback();
                obj_con.Close();
                obj_con.Dispose();
                ds = null;
                return ds;
            }

            if (obj_con.State == ConnectionState.Closed || obj_con.State == ConnectionState.Broken)
            {
                ds = null;
                return ds;

            }


            try
            {

                obj_cmd.Connection = obj_con;

            }
            catch (Exception e)
            {


                obj_con.Close();
                ds = null;
                return ds;

            }

            try
            {

                obj_cmd.Transaction = obj_trn;


            }
            catch (Exception ee)
            {
                obj_trn.Rollback();
                ds = null;

                return ds;

            }

            obj_cmd.CommandType = CommandType.Text;
            obj_cmd.CommandText = query;
            //obj_cmd.Parameters.Clear();
            try
            {

                //for (int x = 0; x < sql_param.Length; x++)
                //{

                //    obj_cmd.Parameters.Add(sql_param[x]);

                //}

            }
            catch (Exception eeee)
            {

                obj_con.Close();
                obj_con.Dispose();
                return ds;

            }



            try
            {

                SqlDataAdapter da = new SqlDataAdapter(obj_cmd);

                ds = new DataSet();

                da.Fill(ds);

                da.Dispose();
                obj_con.Close();
                obj_con.Dispose();
            }

            catch (Exception eee)
            {

                obj_con.Close();
                obj_con.Dispose();

                ds = null;
                return ds;
            }

            try
            {
                closeconnection();
                obj_cmd.Parameters.Clear();
            }
            catch (Exception eeeee)
            {

                obj_con.Close();
                ds = null;
                return ds;
            }

            return ds;

        }
        public DataSet selectionWithSeparateDatabase(string query, string database)
        {

            try
            {

                string customConnectionString = "";
                SqlConnection customeConnection;

                if (USERID == "" || PASSWORD == "")

                    customConnectionString = @"Data Source=" + SERVERNAME + "; Database=" + database + "; Integrated Security=True;";
                else

                    customConnectionString = "Data Source=" + SERVERNAME + "; Database=" + database + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";



                customeConnection = new SqlConnection();
                customeConnection.ConnectionString = customConnectionString;
                customeConnection.Open();
                SqlCommand obj_cmd = new SqlCommand();
                obj_cmd.Connection = customeConnection;
                obj_cmd.CommandType = CommandType.Text;
                obj_cmd.CommandText = query;


                SqlDataAdapter da = new SqlDataAdapter(obj_cmd);
                ds = new DataSet();
                da.Fill(ds);
                customeConnection.Close();
                customeConnection.Dispose();

                return ds;
            }
            catch (Exception ex)
            {

                return null;
            }
        }







        public DataSet selection(string query, Boolean status)
        {

            SqlCommand obj_cmd = new SqlCommand();

            //obj_cmd.Connection = obj_con;
            //obj_cmd.CommandType = CommandType.StoredProcedure;
            //obj_cmd.CommandText = storeprocedure;


            //for (int x = 0; x < sql_param.Length; x++)
            //{

            //    obj_cmd.Parameters.Add(sql_param[x]);

            //}
            //open_connection();
            try
            {
                string state = open_connection(false);
            }
            catch (Exception eee)
            {
                obj_trn.Rollback();
                obj_con.Close();
                obj_con.Dispose();
                ds = null;
                return ds;
            }

            if (obj_con.State == ConnectionState.Closed || obj_con.State == ConnectionState.Broken)
            {
                ds = null;
                return ds;

            }


            try
            {

                obj_cmd.Connection = obj_con;

            }
            catch (Exception e)
            {


                obj_con.Close();
                ds = null;
                return ds;

            }

            try
            {

                obj_cmd.Transaction = obj_trn;


            }
            catch (Exception ee)
            {
                obj_trn.Rollback();
                ds = null;

                return ds;

            }

            obj_cmd.CommandType = CommandType.Text;
            obj_cmd.CommandText = query;
            //obj_cmd.Parameters.Clear();
            try
            {

                //for (int x = 0; x < sql_param.Length; x++)
                //{

                //    obj_cmd.Parameters.Add(sql_param[x]);

                //}

            }
            catch (Exception eeee)
            {

                obj_con.Close();
                obj_con.Dispose();
                return ds;

            }



            try
            {

                SqlDataAdapter da = new SqlDataAdapter(obj_cmd);

                ds = new DataSet();

                da.Fill(ds);

                da.Dispose();
                obj_con.Close();
                obj_con.Dispose();
            }

            catch (Exception eee)
            {

                obj_con.Close();
                obj_con.Dispose();

                ds = null;
                return ds;
            }

            try
            {
                closeconnection();
                obj_cmd.Parameters.Clear();
            }
            catch (Exception eeeee)
            {

                obj_con.Close();
                ds = null;
                return ds;
            }

            return ds;

        }
        public DataSet selection(string queryForMySQL, string thisIsforMySQl, string thisIsforMySQl2)
        {

            MySqlCommand obj_cmd = new MySqlCommand();
            MySqlConnection obj_conMySQL = new MySqlConnection();

            try
            {
                // obj_con = new SqlConnection();
                obj_conMySQL.ConnectionString = "Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";//@"Data Source=localhost; Database=mysql; User Id=root; Password=;";
                obj_conMySQL.Open();


            }
            catch (Exception e)
            {
                obj_conMySQL.Close();
                obj_conMySQL.Dispose();
                return null;

            }


            //obj_cmd.Connection = obj_con;
            //obj_cmd.CommandType = CommandType.StoredProcedure;
            //obj_cmd.CommandText = storeprocedure;


            //for (int x = 0; x < sql_param.Length; x++)
            //{

            //    obj_cmd.Parameters.Add(sql_param[x]);

            //}
            //open_connection();


            if (obj_conMySQL.State == ConnectionState.Closed || obj_conMySQL.State == ConnectionState.Broken)
            {
                ds = null;
                return ds;

            }


            try
            {

                obj_cmd.Connection = obj_conMySQL;

            }
            catch (Exception e)
            {


                obj_conMySQL.Close();
                ds = null;
                return ds;

            }



            obj_cmd.CommandType = CommandType.Text;
            obj_cmd.CommandText = queryForMySQL;
            //obj_cmd.Parameters.Clear();




            try
            {

                MySqlDataAdapter da = new MySqlDataAdapter(obj_cmd);

                ds = new DataSet();

                da.Fill(ds);

                da.Dispose();
                obj_conMySQL.Close();
                obj_conMySQL.Dispose();
            }

            catch (Exception eee)
            {

                obj_conMySQL.Close();
                obj_conMySQL.Dispose();

                ds = null;
                return ds;
            }


            return ds;

        }



        public string connectionstring_1 = string.Empty;
        private string f_connectionstring(Boolean database)
        {
            if (database == true)
            {
                if (USERID == "" || PASSWORD == "")

                    connectionstring_1 = @"Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; Integrated Security=True;";
                else
                    connectionstring_1 = @"Data Source=" + SERVERNAME + "; Database=" + DATABASE + "; User Id=" + USERID + "; Password=" + PASSWORD + ";";



            }

            else if (database == false)
            {

                if (USERID == "" || PASSWORD == "")

                    connectionstring_1 = @"Data Source=" + SERVERNAME + "; Database=; Integrated Security=True;";

                else

                    connectionstring_1 = @"Data Source=" + SERVERNAME + "; Database= ; User Id=" + USERID + "; Password=" + PASSWORD + ";";


            }

            return connectionstring_1;
        }



    }



}
