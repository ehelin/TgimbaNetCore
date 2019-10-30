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
                var hashedPassword = this.passwordHelper.HashPassword(passwordDto);
                var passwordsMatch = this.passwordHelper.PasswordsMatch(hashedPassword, user);

                if (passwordsMatch)
                {
                    var jwtPrivateKey = this.generatorHelper.GetJwtPrivateKey();
                    var jwtIssuer = this.generatorHelper.GetJwtIssuer();
                    token = this.generatorHelper.GetJwtToken(jwtPrivateKey, jwtIssuer);
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

            var validUserRegistration = this.generatorHelper.IsValidUserToRegister(decodedUserName, decodedEmail, decodedPassword);

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
            //throw new NotImplementedException();
            //==============================================
            string[] result = null;
            var validToken = false;

            string decodedBucketListItems = this.stringHelper.DecodeBase64String(encodedBucketListItems);
            string decodedToken = this.stringHelper.DecodeBase64String(encodedToken);
            string decodedUserName = this.stringHelper.DecodeBase64String(encodedUser);

            decodedBucketListItems = decodedBucketListItems.Trim(',');
            decodedBucketListItems = decodedBucketListItems.Trim(';');
            string[] items = decodedBucketListItems.Split(',');

            var user = this.bucketListData.GetUser(decodedUserName);


            // TODO - handle demo user at client so they cannot upsert values

            //=================================================
            // TODO - implement valid token code (this is from previous implementation)
            //bool goodToken = false;
            //IMemberShipData_Old msd = new MemberShipData(Utilities.GetDbSetting());
            //User u = msd.GetUser(userName);

            //HACK for android
            decodedToken = decodedToken.Replace("\"", "");

            if (user != null
                    && !string.IsNullOrEmpty(user.Token)
                        && !string.IsNullOrEmpty(decodedToken)
                            && user.Token.Equals(decodedToken))
            {
                byte[] data = Convert.FromBase64String(decodedToken);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                DateTime now = DateTime.UtcNow.AddHours(-2);
                if (when >= now)
                {
                    // TODO - refactor this?
                    validToken = true;
                }
            }

            //return goodToken;
            //=================================================

            if (validToken)
            {
                //=========================================================
                // TODO - get bucket list item from string[] and add to db using entity framework code (this is from previous code)
                //bool goodDbAction = false;
                //bool Achieved = false;

                //string ListItemName = bucketListItems[0];
                //DateTime Created = this.GetSafeDateTime(bucketListItems[1]);
                //string Category = bucketListItems[2];
                //string AchievedStr = bucketListItems[3];
                //decimal Latitude = this.GetSafeDecimal(bucketListItems[4]);
                //decimal Longitude = this.GetSafeDecimal(bucketListItems[5]);

                //int BucketListItemId = 0;
                //if (!string.IsNullOrEmpty(bucketListItems[6]))
                //    BucketListItemId = this.GetSafeInt(bucketListItems[6]);

                //string UserName = bucketListItems[7];

                //if (!string.IsNullOrEmpty(AchievedStr) && AchievedStr.Equals("1"))
                //    Achieved = true;

                //goodDbAction = UpsertBucketListItemV2(ListItemName, Created, Category, Achieved, BucketListItemId, UserName, Latitude, Longitude);

                //return goodDbAction;
                //bld.UpsertBucketListItemV2(items);
                //=========================================================

                result = this.generatorHelper.GetValidTokenResponse();
            }
            else
            {
                result = this.generatorHelper.GetInValidTokenResponse();
            }
            

            return result;
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
