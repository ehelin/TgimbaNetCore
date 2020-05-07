using System;
using System.Text;

namespace Shared.misc
{
    public class Utilities
    {
        public static string GetDbSetting()
        {
            string dbConn = Environment.GetEnvironmentVariable("dataConnectionString");

            if (string.IsNullOrEmpty(dbConn))
            {
                dbConn = Credentials.GetDbConnection();
                //dbConn = Credentials.GetDbConnectionTest();
            }
           
            return dbConn;
        }

        public static string GetTestDbSetting()
        {
            return Credentials.GetDbConnectionTest();
        }

        public static string DecodeClientBase64String(string encodedString)
        {
            string decodedString = string.Empty;

            if (!string.IsNullOrEmpty(encodedString))
            {
                byte[] data = Convert.FromBase64String(encodedString);
                decodedString = Encoding.UTF8.GetString(data);
            }

            return decodedString;
        }

        public static string EncodeClientBase64String(string val)
        {
            string encodedString = string.Empty;

            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(val);
                encodedString = Convert.ToBase64String(data);
            }

            return encodedString;
        }
    }
}
