using System;
using System.Collections.Generic;
using Shared;
using Shared.dto;
using Shared.interfaces;
using Shared.misc;

namespace APINetCore
{
    public class TgimbaService : ITgimbaService
    {
        private IBucketListData bucketListData = null;
        private IPassword passwordHelper = null;
        private IGenerator generatorHelper = null;
        private IString stringHelper = null;
        private IConversion conversionHelper = null;

        public TgimbaService
        (
            IBucketListData bucketListData, 
            IPassword passwordHelper, 
            IGenerator generatorHelper,
            IString stringHelper,
            IConversion conversionHelper
        ) {
            this.bucketListData = bucketListData;
            this.passwordHelper = passwordHelper;
            this.generatorHelper = generatorHelper;
            this.stringHelper = stringHelper;
            this.conversionHelper = conversionHelper;
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
                var hashedPassword = this.passwordHelper.HashPassword(passwordDto);
                var passwordsMatch = this.passwordHelper.PasswordsMatch(hashedPassword, user);

                if (passwordsMatch)
                {
                    var jwtPrivateKey = this.generatorHelper.GetJwtPrivateKey();
                    var jwtIssuer = this.generatorHelper.GetJwtIssuer();
                    token = this.generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer);

                    if (!string.IsNullOrEmpty(token))
                    {
                        this.bucketListData.AddToken(user.UserId, token);
                    }
                }
            }

            return token;
        }

        public bool ProcessUserRegistration(string encodedUserName, string encodedEmail, string encodedPassword)
        {
            bool userAdded = false;

            string decodedUserName = this.stringHelper.DecodeBase64String(encodedUserName);
            string decodedEmail = this.stringHelper.DecodeBase64String(encodedEmail);
            string decodedPassword = this.stringHelper.DecodeBase64String(encodedPassword);

            var validUserRegistration = this.passwordHelper.IsValidUserToRegister(decodedUserName, decodedEmail, decodedPassword);

            if (validUserRegistration)
            {
                var user = new User();
                user.Salt = this.passwordHelper.GetSalt(Constants.SALT_SIZE);

                var np = new Password(decodedPassword, user.Salt);
                var p = this.passwordHelper.HashPassword(np);

                user.Password = p.SaltedHashedPassword;
                user.UserName = decodedUserName;
                user.Email = decodedEmail;

                var userId = this.bucketListData.AddUser(user);
                if (userId > 0) 
                {
                    userAdded = true;
                }
            }

            return userAdded;
        }

        #endregion

        #region BucketList

        public bool DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken)
        {
            throw new NotImplementedException();
        }

        public IList<BucketListItem> GetBucketListItems
        (
            string encodedUserName, 
            string encodedSortString, 
            string encodedToken, 
            string encodedSrchString = ""
        ) {
            IList <BucketListItem> bucketListItems = null;

            string decodedUserName = this.stringHelper.DecodeBase64String(encodedUserName);
            string decodedSortString = this.stringHelper.DecodeBase64String(encodedSortString);
            string decodedToken = this.stringHelper.DecodeBase64String(encodedToken);
            string decodedSrchString = this.stringHelper.DecodeBase64String(encodedSrchString);

            var user = this.bucketListData.GetUser(decodedUserName);
            var validToken = this.passwordHelper.IsValidToken(user, decodedToken);

            if (validToken)
            {
                Enums.SortColumns? sortColumn = null;
                bool sortAsc = false;

                if (!string.IsNullOrEmpty(decodedSortString))
                {
                    sortColumn = this.stringHelper.GetSortColumn(decodedSortString);
                    sortAsc = this.stringHelper.HasSortOrderAsc(decodedSortString);
                }
               
                bucketListItems = this.bucketListData.GetBucketList(decodedUserName, sortColumn, sortAsc, decodedSrchString);               
            }

            return bucketListItems;
        }

        public bool UpsertBucketListItem(BucketListItem bucketListItem, string encodedUser, string encodedToken)
        {
            // TODO - handle demo user at client so they cannot upsert values
            bool goodUpsert = false;

            string decodedToken = this.stringHelper.DecodeBase64String(encodedToken);
            string decodedUserName = this.stringHelper.DecodeBase64String(encodedUser);

            var user = this.bucketListData.GetUser(decodedUserName);
            var validToken = this.passwordHelper.IsValidToken(user, decodedToken);

            if (validToken)
            {
                this.bucketListData.UpsertBucketListItem(bucketListItem, decodedUserName);
                goodUpsert = true;
            }          

            return goodUpsert;
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
