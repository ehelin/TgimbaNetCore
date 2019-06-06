using System;
using System.Data.SqlClient;
using Shared.interfaces;

namespace TgimbaSupport
{
    public class TgimbaDatabase : ITgimbaDatabase
    {
        private string connectionString = string.Empty;

        public TgimbaDatabase(string pConnectionString)
        {
            connectionString = pConnectionString;
        }

        public void SaveWebsiteStatus(bool websiteIsUp)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            string connStr = string.Empty;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Bucket.SystemStatistics "
                                + "select @websiteIsUp, 1, 1, GETUTCDATE()";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@websiteIsUp", websiteIsUp));

                cmd.Connection.Open();

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
    }
}
