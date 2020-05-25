using System;
using System.Data.SqlClient;
using Newtonsoft.Json;

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

        #region Unit Test Environment Variables

        public static void ClearEnvironmentalVariablesForUnitTests()
        {
            Environment.SetEnvironmentVariable("JwtPrivateKey", null);
            Environment.SetEnvironmentVariable("JwtIssuer", null);
        }

        public static void SetEnvironmentalVariablesForUnitTests()
        {
            Environment.SetEnvironmentVariable("JwtPrivateKey", "123134123412341341AEARSERAserae54893475384983945vsdeausceauiseycauie");
            Environment.SetEnvironmentVariable("JwtIssuer", "IAmAJstIssuer");
        }

        #endregion

        #region Integration Test Environment Variables

        public static void ClearEnvironmentalVariablesForIntegrationTests()
        {
            Environment.SetEnvironmentVariable("JwtPrivateKey", null);
            Environment.SetEnvironmentVariable("JwtIssuer", null);
            Environment.SetEnvironmentVariable("DbConnectionTest", null);
            Environment.SetEnvironmentVariable("DbConnection", null);
        }

        public static void SetEnvironmentalVariablesForIntegrationTests()
        {
            var fileContents = System.IO.File.ReadAllText("Properties\\launchSettings.json");
            dynamic jsonValues = JsonConvert.DeserializeObject(fileContents);
            
            foreach (dynamic levelOne in jsonValues.profiles)
            {
                foreach (dynamic levelTwo in levelOne)
                {
                    foreach (dynamic environmentVariable in levelTwo.environmentVariables)
                    {
                        Environment.SetEnvironmentVariable(environmentVariable.Name, environmentVariable.Value.ToString());
                    }
                }
            }
        }

        #endregion
    }
}
