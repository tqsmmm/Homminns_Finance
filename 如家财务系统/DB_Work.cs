using System;
using System.Data;
using System.Data.SqlClient;

namespace 如家财务系统
{
    internal class DB_Work
    {
        public static bool ExecuteCmd(string strSQL, SqlConnection SqlConn)
        {
            try
            {
                var CmdObj = new SqlCommand(strSQL, SqlConn);
                SqlConn.Open();
                CmdObj.ExecuteNonQuery();
                SqlConn.Close();

                return true;
            }
            catch (Exception Ex)
            {
                Public.Sys_MsgBox(Ex.Message);
                return false;
            }
            finally
            {
                if (SqlConn.State != ConnectionState.Closed)
                {
                    SqlConn.Close();
                }
            }
        }
        public static DataSet DataSetCmd(string strSQL, SqlConnection SqlConn)
        {
            try
            {
                var Ds = new DataSet();
                var DaPayType = new SqlDataAdapter(strSQL, SqlConn);
                DaPayType.Fill(Ds, "Table");
                SqlConn.Close();

                return Ds;
            }
            catch (Exception e)
            {
                Public.Sys_MsgBox(e.Message);
                return null;
            }
            finally
            {
                if (SqlConn.State != ConnectionState.Closed)
                {
                    SqlConn.Close();
                }
            }
        }

        public static bool ConnectionTest(SqlConnection strConn)
        {
            try
            {
                if (strConn.State != ConnectionState.Open)
                {
                    strConn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (strConn.State != ConnectionState.Closed)
                {
                    strConn.Close();
                }
            }
        }
    }
}
