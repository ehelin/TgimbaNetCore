using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.misc.sql;
using Shared.interfaces;
using Shared.dto;

namespace DAL.providers
{
    public partial class BucketListData : BaseBucketListData, IBucketListData_Old
    {
        public BucketListData(string pConnectionString)
        {
            connectionString = pConnectionString;
        }

        public string GetReport()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;
            string result = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "bucket.getreport";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    result = GetSafeString(rdr[0]);
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

            return result;
        }

        public string[] GetDashboard()
        {
            IDictionary<string, string> dashboardItems = GetDashboardItems();
            string[] results = ParseDictionary(dashboardItems);

            return results;
        }

        public string[] GetBucketList(string userName, string sortString)
        {
            IList<BucketListItem> listItems = GetListItemsV1(userName, sortString);
            string[] items = null;
            int ctr = 0;
            int ctrDisplay = 1;

            if (listItems == null || listItems.Count < 1)
            {
                items = new string[1];
                items[0] = "No Items";
            }
            else
            {
                items = new string[listItems.Count];

                foreach (BucketListItem bli in listItems)
                {
                    items[ctr] = "," + bli.Name
                                    + "," + bli.Created.ToString("MM/dd/yyyy").Trim('0')
                                        + "," + bli.Category
                                            + "," + bli.GetIntStringAchievedValue()
                                            + "," + bli.Id.ToString();
                    ctr++;
                    ctrDisplay++;
                }
            }

            return items;
        }

        public bool DeleteBucketListItem(int bucketListItemDbId)
        {
            bool goodDelete = this.DeleteBucketList(bucketListItemDbId);

            return goodDelete;
        }

        public bool UpsertBucketListItem(string[] bucketListItems)
        {
            bool goodDbAction = false;
            bool Achieved = false;

            string ListItemName = bucketListItems[0];
            DateTime Created = this.GetSafeDateTime(bucketListItems[1]);
            string Category = bucketListItems[2];
            string AchievedStr = bucketListItems[3];
            int BucketListItemId = this.GetSafeInt(bucketListItems[4]);
            string UserName = bucketListItems[5];

            if (!string.IsNullOrEmpty(AchievedStr) && AchievedStr.Equals("1"))
                Achieved = true;

            goodDbAction = UpsertBucketListItemV1(ListItemName, Created, Category, Achieved, BucketListItemId, UserName);

            return goodDbAction;
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
                cmd.CommandText = BucketListSql.LOG_ACTION;
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

        #region Private Methods

        private IList<BucketListItem> GetListItemsV1(string userName, string sortString)
        {
            IList<BucketListItem> listItems = new List<BucketListItem>();
            BucketListItem bli = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            SqlDataReader rdr = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();

                if (!string.IsNullOrEmpty(sortString))
                {
                    //HACK - Update in a later version
                    if (sortString.Equals(" order by Category"))
                        cmd.CommandText = BucketListSql.GET_BUCKET_LIST + "order by CategorySortOrder";
                    else if (sortString.Equals(" order by Category desc"))
                        cmd.CommandText = BucketListSql.GET_BUCKET_LIST + "order by CategorySortOrder desc";
                    else
                        cmd.CommandText = BucketListSql.GET_BUCKET_LIST + sortString;
                }
                else
                    cmd.CommandText = BucketListSql.GET_BUCKET_LIST;

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));

                cmd.Connection.Open();

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    bli = new BucketListItem();

                    bli.Name = GetSafeString(rdr[0]);
                    bli.Created = GetSafeDateTime(rdr[1]);
                    bli.Category = GetSafeString(rdr[2]);
                    bli.Achieved = GetSafeBool(rdr[3]);
                    bli.Id = GetSafeInt(rdr[4]);

                    listItems.Add(bli);
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

            return listItems;
        }

        private bool UpsertBucketListItemV1(string ListItemName,
                                            DateTime Created,
                                            string Category,
                                            bool Achieved,
                                            int BucketListItemId,
                                            string UserName)
        {
            IList<BucketListItem> listItems = new List<BucketListItem>();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            bool goodDbAction = false;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = BucketListSql.UPSERT_BUCKET_LIST_ITEM;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@BucketListItemId", BucketListItemId));
                cmd.Parameters.Add(new SqlParameter("@ListItemName", ListItemName));
                cmd.Parameters.Add(new SqlParameter("@Created", Created));
                cmd.Parameters.Add(new SqlParameter("@Category", Category));
                cmd.Parameters.Add(new SqlParameter("@Achieved", Achieved));
                cmd.Parameters.Add(new SqlParameter("@UserName", UserName));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();

                goodDbAction = true;
            }
            catch (Exception ex)
            {
                LogMsg(ex.Message);
            }
            finally
            {
                CloseDbObjects(conn, cmd, null);
            }

            return goodDbAction;
        }

        #endregion
    }
}
