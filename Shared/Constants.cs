using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Constants
    {
        public const string MOBILE = "DesktopHome";
        public const string NON_MOBILE = "MobileHome";
        public const string TOKEN_VALID = "TokenValid";
        public const string CATEGORY = "Category";

        public const string ENVIRONMENT = "Environment";
        public const string ENVIRONMENT_TEST = "Test";
        public const string ENVIRONMENT_PRODUCTION = "Production";
        public const string DB_PROD = "BucketListDbConnStrProd";
        public const string DB_TEST = "BucketListDbConnStrDev";

        public const int REGISTRATION_VALUE_LENGTH = 8;
        public const string EMAIL_AT_SIGN = "@";
        public const string API_TEST_RESULT = "Test Service Response";

        public const int SALT_SIZE = 32;            //arbitrary value read in article
        public const int HASH_ITERATIONS = 1000;    //arbitrary value read in article
        public const int KEY_LENGTH = 250;         //arbitrary value read in article

        //Demo user
        public const string DEMO_USER = "demouser";
        public const string DEMO_USER_PASSWORD = "demouserPass123";
    }

    public class Error
    {
        public const string ERR_000001 = "ERR_000001";
        public const string ERR_000002 = "ERR_000002";
    }

    public class ErrorMsg
    {
        public const string ERR_MSG_000001 = "No httpcontext object";
        public const string ERR_MSG_000002 = "Token Expired";
    }
}
