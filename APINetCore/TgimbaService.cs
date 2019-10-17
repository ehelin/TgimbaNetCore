using System;
using System.Collections.Generic;
using Shared;
using Shared.dto;
using Shared.interfaces;

namespace APINetCore
{
    public class TgimbaService : ITgimbaService
    {
        private IBucketListData bucketListData = null;
        private IPassword passwordHelper = null;
        private IGenerator generatorHelper = null;
        private IString stringHelper = null;

        public TgimbaService
        (
            IBucketListData bucketListData, 
            IPassword passwordHelper, 
            IGenerator generatorHelper,
            IString stringHelper
        ) {
            this.bucketListData = bucketListData;
            this.passwordHelper = passwordHelper;
            this.generatorHelper = generatorHelper;
            this.stringHelper = stringHelper;
        }

        #region User 

        public string ProcessUser(string encodedUserName, string encodedPassword)
        {
            string token = string.Empty;
            string decodedUserName = this.stringHelper.DecodeBase64String(encodedUserName);
            string decodedPassword = this.stringHelper.DecodeBase64String(encodedPassword);
            var user = this.bucketListData.GetUser(decodedUserName);

            if (user != null)
            {
                var passwordDto = new Password(decodedPassword, user.Salt);

                // TODO - update tests to handle this addition
                var hashedPassword = this.passwordHelper.HashPassword(passwordDto);

                var passwordsMatch = this.passwordHelper.PasswordsMatch(passwordDto, user);

                if (passwordsMatch)
                {
                    var jwtPrivateKey = this.generatorHelper.GetJwtPrivateKey();
                    var jwtIssuer = this.generatorHelper.GetJwtIssuer();
                    token = this.generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer);
                }
            }

            return token;
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
            string jwtToken = null;
            var user = this.bucketListData.GetUser(Constants.DEMO_USER);

            if (user != null)
            {
                var password = new Password(Constants.DEMO_USER_PASSWORD);
                var passwordDto = this.passwordHelper.HashPassword(password);
                var passwordsMatch = this.passwordHelper.PasswordsMatch(passwordDto, user);

                if (passwordsMatch) 
                {
                    var jwtPrivateKey = this.generatorHelper.GetJwtPrivateKey();
                    var jwtIssuer = this.generatorHelper.GetJwtIssuer();
                    jwtToken = this.generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer);
                }
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
