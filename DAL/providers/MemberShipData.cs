using System;
using System.Data.SqlClient;
using DAL.misc.sql;
using Shared.interfaces;
using Shared.dto;

namespace DAL.providers
{
    public class MemberShipData : IMemberShipData_Old
    {
        private string connectionString = string.Empty;

        public MemberShipData(string pConnectionString)
        {
            connectionString = pConnectionString;
        }
        public void AddToken(string userName, string token)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            string connStr = string.Empty;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = MembershipSql.ADD_USER_TOKEN;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));
                cmd.Parameters.Add(new SqlParameter("@token", token));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }
        }
        public User GetUser(string userName)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            User u = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = MembershipSql.USER_EXISTS;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));

                cmd.Connection.Open();

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    u = new User();

                    u.UserId = GetSafeInt(rdr[0]);
                    u.UserName = GetSafeString(rdr[1]);
                    u.Salt = GetSafeString(rdr[2]);
                    u.Password = GetSafeString(rdr[3]);
                    u.Email = GetSafeString(rdr[4]);
                    u.Token = GetSafeString(rdr[5]);
                }
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
            }
            finally
            {
                CloseDbObjects(conn, cmd, rdr);
            }

            return u;
        }
        public void LogMsg(string msg)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            string curFile = string.Empty;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = MembershipSql.LOG_ACTION;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@LogMessage", msg));

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }
        }
        public bool AddUser(string userName, string email, string passWord, string salt)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            bool goodInsert = false;
            string connStr = string.Empty;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = MembershipSql.INSERT_USER;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));
                cmd.Parameters.Add(new SqlParameter("@passWord", passWord));
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@salt", salt));

                cmd.Connection.Open();

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    goodInsert = GetSafeBool(rdr[0]);
                }
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }

            return goodInsert;
        }
        public bool DeleteUser(string userName, string passWord, string email)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            bool goodDelete = false;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = MembershipSql.DELETE_USER;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));
                // TODO - either work in getting the encrypted password or remove from here
                //cmd.Parameters.Add(new SqlParameter("@passWord", passWord));
                cmd.Parameters.Add(new SqlParameter("@email", email));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                goodDelete = true;
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }

            return goodDelete;
        }

        #region support

        private void CloseDbObjects(SqlConnection conn, SqlCommand cmd, SqlDataReader rdr)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }

            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }

            if (rdr != null)
            {
                rdr.Close();
                rdr.Dispose();
                rdr = null;
            }
        }
        private bool GetSafeBool(object val)
        {
            bool result = false;

            if (val != DBNull.Value && val != null)
                result = Convert.ToBoolean(val);

            return result;
        }
        private int GetSafeInt(object val)
        {
            int result = 0;

            if (val != DBNull.Value && val != null)
                result = Convert.ToInt32(val);

            return result;
        }
        private string GetSafeString(object val)
        {
            string result = string.Empty;

            if (val != DBNull.Value && val != null)
                result = val.ToString();

            return result;
        }

        #endregion
    }
}
