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
        private IPassword passwordHelper = null;
        private IGenerator generatorHelper = null;

        public TgimbaService(IBucketListData bucketListData, IPassword passwordHelper, IGenerator generatorHelper)
        {
            this.bucketListData = bucketListData;
            this.passwordHelper = passwordHelper;
            this.generatorHelper = generatorHelper;
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
            string jwtToken = string.Empty;
            var user = this.bucketListData.GetUser(Constants.DEMO_USER);
            var password = new Password(Constants.DEMO_USER_PASSWORD);
            var passwordDto = this.passwordHelper.HashPassword(password);

            if (user != null 
                    && this.passwordHelper.PasswordsMatch(passwordDto, user))
            {
                var jwtPrivateKey = this.generatorHelper.GetJwtPrivateKey();
                var jwtIssuer = this.generatorHelper.GetJwtIssuer();
                jwtToken = this.generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer);
            }

            return jwtToken;
        }

        public string GetTestResult()
        {
            return Constants.API_TEST_RESULT;
        }

        #endregion
    }
}
