using System;
using System.Data.SqlClient;

namespace Shared.misc.testUtilities
{
    public class TestUtilities
    {
        private const string DELETE_TEST_USER = "delete from [Bucket].[BucketListItem]   "
                                   + " where bucketlistitemid in (select bucketListItemId   "
                                   + "                            from [Bucket].[BucketListUser]   "
                                   + " 						   where userid in (select userid   "
                                   + " 						                    from [Bucket].[User]   "
                                   + " 										    where UserName = @userName)   "
                                   + " 						   )   "
                                   + "    "
                                   + " delete from [Bucket].[BucketListUser]   "
                                   + " where userid in (select userid   "
                                   + " 				from [Bucket].[User]   "
                                   + " 				where UserName = @userName)   "
                                   + "    "
                                   + " delete from [Bucket].[User]   "
                                   + " where UserName = @userName ";

        private const string DELETE_TEST_USER_BUCKET_LIST_ITEMS = "delete from [Bucket].[BucketListItem]   "
                           + " where bucketlistitemid in (select bucketListItemId   "
                           + "                            from [Bucket].[BucketListUser]   "
                           + " 						   where userid in (select userid   "
                           + " 						                    from [Bucket].[User]   "
                           + " 										    where UserName = @userName)   "
                           + " 						   )   "
                           + "    "
                           + " delete from [Bucket].[BucketListUser]   "
                           + " where userid in (select userid   "
                           + " 				from [Bucket].[User]   "
                           + " 				where UserName = @userName)   ";

        public void CleanUpLocal(string user, bool deleteBucketListItems = false)
        {
            //var connectionString = Shared.misc.Utilities.GetTestDbSetting();
            var connectionString = Shared.misc.Utilities.GetDbSetting();
            DeleteTestUser(user, connectionString, deleteBucketListItems);
        }

        private void DeleteTestUser(string userName, string connectionString, bool deleteBucketListItems)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = deleteBucketListItems ? DELETE_TEST_USER_BUCKET_LIST_ITEMS : DELETE_TEST_USER;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
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
            }
        }
    }
}
