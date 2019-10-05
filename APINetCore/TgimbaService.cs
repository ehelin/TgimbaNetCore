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

        public TgimbaService(IBucketListData bucketListData)
        {
            this.bucketListData = bucketListData;
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

        public string LoginDemoUser() 
        {
            //var user = this.bucketListData.GetUser(Constants.DEMO_USER);
            // sub test => VerifyUser(args)
            // sub sub test => GetUser(userName)
            // sub sub test => UserExists(user, password)
            // sub sub sub test => ComparePasswords(user, supplied password)
            // sub sub sub test => HashPassword(new password)
            // sub sub test => GenerateToken()

            throw new NotImplementedException();
        }

        public string GetTestResult()
        {
            return Constants.API_TEST_RESULT;
        }

        #endregion
    }
}
