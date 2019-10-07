using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.interfaces;
using System.Net;
using Shared;

namespace APINetCore
{
    public class TgimbaService : ITgimbaService
    {
        private IBucketListData bucketListData = null;
        private IPassword password = null;

        public TgimbaService(IBucketListData bucketListData, IPassword password)
        {
            this.bucketListData = bucketListData;
            this.password = password;
        }

        #region User 

        public string ProcessUser(string encodedUser, string encodedPass)
        {
            throw new NotImplementedException();
        }

        public bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BucketList

        public string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken)
        {
            throw new NotImplementedException();
        }

        public string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken, string encodedSrchString = "")
        {
            throw new NotImplementedException();
        }

        public string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Misc

        public IList<SystemBuildStatistic> GetSystemBuildStatistics()
        {
            var systemBuildStatistics = this.bucketListData.GetSystemBuildStatistics();
            return systemBuildStatistics;
        }

        public IList<SystemStatistic> GetSystemStatistics()
        {
            var systemBuildStatistics = this.bucketListData.GetSystemStatistics();
            return systemBuildStatistics;
        }

        public void Log(string msg)
        {
            this.bucketListData.LogMsg(msg);
        }

        // TODO - once method is done, add service level test and
        // TODO - once method/test done, add api method/test
        public string LoginDemoUser() 
        {
            // TODO - token needs to be a JWT token
            string token = string.Empty;
            var user = this.bucketListData.GetUser(Constants.DEMO_USER);

            if (user != null 
                    && this.password.PasswordsMatch(Constants.DEMO_USER_PASSWORD, user.Salt, user.Password))
            {
                // TODO - this token needs to be a JWTtoken
                // sub sub test => GenerateToken()
            }

            throw new NotImplementedException();
        }

        public string GetTestResult()
        {
            return Constants.API_TEST_RESULT;
        }

        #endregion
    }
}
