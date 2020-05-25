namespace Shared.misc
{
    public class EnvironmentalConfig
    {
        public static string GetDbSetting(bool useTestDb = false)
        {
            string dbConn = string.Empty;

            if (useTestDb)
            {
                dbConn = System.Environment.GetEnvironmentVariable("DbConnectionTest");
            }
            else
            {
                dbConn = System.Environment.GetEnvironmentVariable("DbConnection");
            }

            return dbConn;
        }

        public static string GetJwtPrivateKey()
        {
            var key = System.Environment.GetEnvironmentVariable("JwtPrivateKey");

            return key;
        }

        public static string GetJwtIssuer()
        {
            var key = System.Environment.GetEnvironmentVariable("JwtIssuer");

            return key;
        }
    }
}
