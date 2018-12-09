using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Shared.dto;
using DAL.misc.sql;

namespace DAL.providers
{
    public class BaseBucketListData
    {
        protected string connectionString = string.Empty;

        #region protected Methods

        protected SqlParameter HandleNullParameters(string parameterName,
                                                    object val,
                                                    System.Data.SqlDbType dbType,
                                                    System.Data.ParameterDirection dir)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = dir;

            if (dbType == System.Data.SqlDbType.Int)
            {
                if (val == null || Convert.ToInt32(val) < 0)
                    param.Value = 0;
                else
                    param.Value = Convert.ToInt32(val);
            }
            else if (dbType == System.Data.SqlDbType.VarChar)
            {
                if (val == null)
                    param.Value = string.Empty;
                else
                    param.Value = val.ToString();
            }
            else if (dbType == System.Data.SqlDbType.Bit)
            {
                param.Value = Convert.ToBoolean(val);
            }
            else if (dbType == System.Data.SqlDbType.Float)
            {
                if (val == null || Convert.ToDouble(val) < 0)
                    param.Value = 0;
                else
                    param.Value = (float)Convert.ToDouble(val);
            }

            return param;
        }

        protected bool DeleteBucketList(int BucketListItemId)
        {
            IList<BucketListItem> listItems = new List<BucketListItem>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            bool goodDbAction = false;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = BucketListSql.DELETE_BUCKET_LIST_ITEM;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@BucketListItemId", BucketListItemId));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                goodDbAction = true;
            }
            catch (Exception ex)
            {
                throw ex;// LogMsg(ex.Message);
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }

            return goodDbAction;
        }

        protected IDictionary<string, string> GetDashboardList(string pSql)
        {
            IDictionary<string, string> listItems = new Dictionary<string, string>();
            BucketListItem bli = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = pSql;

                cmd.Connection.Open();

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    listItems.Add(GetSafeString(rdr[0]), GetSafeString(rdr[1]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }

            return listItems;
        }
        protected IDictionary<string, string> GetDashboardItems()
        {
            IDictionary<string, string> dashboardItems = new Dictionary<string, string>();

            //order matters
            foreach (KeyValuePair<string, string> dashboardItem in this.GetDashboardList(DashboardSql.DASHBOARD_USER_SQL))
                dashboardItems.Add(dashboardItem.Key, dashboardItem.Value);

            foreach (KeyValuePair<string, string> dashboardItem in this.GetDashboardList(DashboardSql.DASHBOARD_CATEGORY_SQL))
                dashboardItems.Add(dashboardItem.Key, dashboardItem.Value);

            foreach (KeyValuePair<string, string> dashboardItem in this.GetDashboardList(DashboardSql.DASHBOARD_ACHIEVED_SQL))
                dashboardItems.Add(dashboardItem.Key, dashboardItem.Value);

            foreach (KeyValuePair<string, string> dashboardItem in this.GetDashboardList(DashboardSql.DASHBOARD_CREATED_SQL))
                dashboardItems.Add(dashboardItem.Key, dashboardItem.Value);

            return dashboardItems;
        }
        protected string[] ParseDictionary(IDictionary<string, string> dashboardItems)
        {
            int ctr = 0;
            string[] results = new string[dashboardItems.Count];
            foreach (KeyValuePair<string, string> dashboardItem in dashboardItems)
            {
                if (ctr == 0)
                    results[ctr] = dashboardItem.Value + " " + dashboardItem.Key;
                else
                    results[ctr] = dashboardItem.Value;

                ctr++;
            }

            return results;
        }

        #endregion

        #region support

        protected void CloseDbObjects(SqlConnection conn, SqlCommand cmd, SqlDataReader rdr)
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
        protected bool GetSafeBool(object val)
        {
            bool result = false;

            if (val != DBNull.Value && val != null)
                result = Convert.ToBoolean(val);

            return result;
        }
        protected decimal GetSafeDecimal(object val)
        {
            decimal result = 0;

            if (val != DBNull.Value && val != null)
                result = Convert.ToDecimal(val);

            return result;
        }
        protected int GetSafeInt(object val)
        {
            int result = 0;

            if (val != DBNull.Value && val != null && !string.IsNullOrEmpty(val.ToString()))
                result = Convert.ToInt32(val);

            return result;
        }
        protected string GetSafeString(object val)
        {
            string result = string.Empty;

            if (val != DBNull.Value && val != null)
                result = Convert.ToString(val);

            return result;
        }
        protected DateTime GetSafeDateTime(object val)
        {
            DateTime result = DateTime.MinValue;

            if (val != DBNull.Value && val != null)
                result = Convert.ToDateTime(val);

            return result;
        }

        #endregion
    }
}
