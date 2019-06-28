using DAL.helpers;
using DAL.misc;
using DAL.providers;
using Shared.dto;
using Shared.interfaces;
using Shared.misc;
using System;
using System.Collections.Generic;

namespace API
{
    // TODO - DI databases
    public class TgimbaService : ITgimbaService
    {
        // TODO - DI logger
        private static Enums.LogLevel level = Enums.LogLevel.Info;
        private ILogger logger = new Logger(new BucketListData(Utilities.GetDbSetting()), level);


        public List<SystemStatistic> GetSystemStatistics()
        {
            IBucketListData bld = null;
            List<SystemStatistic> results = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());
                results = bld.GetSystemStatistics();
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return results;
        }

        public string GetReport()
        {
            IBucketListData bld = null;
            string results = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());
                results = bld.GetReport();
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return results;
        }

        public string GetTestResult()
        {
            return "Test Service Response";
        }
        public void Log(string msg, Enums.LogLevel level)
        {
            this.logger.Log(msg, level);
        }
        public string LoginDemoUser()
        {
            string token = string.Empty;
            IMemberShipData msd = null;

            try
            {
                msd = new MemberShipData(Utilities.GetDbSetting());
                token = VerifyUser(Constants.DEMO_USER, Constants.DEMO_USER_PASSWORD, msd);

                if (!string.IsNullOrEmpty(token))
                    msd.AddToken(Constants.DEMO_USER, token);
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return token;
        }
        public string[] GetDashboard()
        {
            IBucketListData bld = null;
            string[] results = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());
                results = bld.GetDashboard();
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return results;
        }
        public string ProcessUser(string encodedUser, string encodedPass)
        {
            IMemberShipData msd = null;
            string token = string.Empty;

            try
            {
                msd = new MemberShipData(Utilities.GetDbSetting());
                string decodedUser = Utilities.DecodeClientBase64String(encodedUser);
                string decodedPass = Utilities.DecodeClientBase64String(encodedPass);

                token = VerifyUser(decodedUser, decodedPass, msd);
                if (!string.IsNullOrEmpty(token))
                    msd.AddToken(decodedUser, token);
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return token;
        }
        public bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass)
        {
            IMemberShipData msd = null;
            bool userAdded = false;

            try
            {
                msd = new MemberShipData(Utilities.GetDbSetting());
                string decodedUser = Utilities.DecodeClientBase64String(encodedUser);
                string decodedEmail = Utilities.DecodeClientBase64String(encodedEmail);
                string decodedPass = Utilities.DecodeClientBase64String(encodedPass);
                
                if (Utilities.ValidUserToRegistration(decodedUser, decodedEmail, decodedPass))
                {
                    PasswordHelper p = new PasswordHelper();
                    NewPassword np = p.GetPassword(decodedPass);
                    userAdded = msd.AddUser(decodedUser, decodedEmail, np.SaltedHashedPassword, np.Salt);
                }
            }
            catch (Exception e)
            {
                msd.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return userAdded;
        }
        public string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedUserName = Utilities.DecodeClientBase64String(encodedUserName);
                string decodedSortString = Utilities.DecodeClientBase64String(encodedSortString);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);

                if (ProcessToken(decodedUserName, decodedToken))
                    result = bld.GetBucketList(decodedUserName, decodedSortString);
                else
                {
                    result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }
        public string[] GetBucketListItemsV2(string encodedUserName, string encodedSortString, 
												string encodedToken, string encodedSrchString = "")
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedUserName = Utilities.DecodeClientBase64String(encodedUserName);
                string decodedSortString = Utilities.DecodeClientBase64String(encodedSortString);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);	   
                string decodedSrchTerm = Utilities.DecodeClientBase64String(encodedSrchString);

                if (ProcessToken(decodedUserName, decodedToken))
                    result = bld.GetBucketListV2(decodedUserName, decodedSortString, decodedSrchTerm);
                else
                {
                    result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }
        public string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedBucketListItems = Utilities.DecodeClientBase64String(encodedBucketListItems);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utilities.DecodeClientBase64String(encodedUser);

                decodedBucketListItems = decodedBucketListItems.Trim(',');
                decodedBucketListItems = decodedBucketListItems.Trim(';');
                string[] items = decodedBucketListItems.Split(',');

                //HACK - needed a demo user quick and I didn't want any changes
                if (!string.IsNullOrEmpty(decodedUserName) && decodedUserName.Equals("demouser"))
                {
                    result = Utilities.GetValidTokenResponse();
                }
                else
                {
                    if (ProcessToken(decodedUserName, decodedToken))
                    {
                        bld.UpsertBucketListItem(items);
                        result = Utilities.GetValidTokenResponse();
                    }
                    else
                        result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }
        public string[] UpsertBucketListItemV2(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedBucketListItems = Utilities.DecodeClientBase64String(encodedBucketListItems);
                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utilities.DecodeClientBase64String(encodedUser);

                decodedBucketListItems = decodedBucketListItems.Trim(',');
                decodedBucketListItems = decodedBucketListItems.Trim(';');
                string[] items = decodedBucketListItems.Split(',');

                //HACK - needed a demo user quick and I didn't want any changes
                if (!string.IsNullOrEmpty(decodedUserName) && decodedUserName.Equals("demouser"))
                {
                    result = Utilities.GetValidTokenResponse();
                }
                else
                {
                    //LogParameters();

                    if (ProcessToken(decodedUserName, decodedToken))
                    {
                        bld.UpsertBucketListItemV2(items);
                        result = Utilities.GetValidTokenResponse();
                    }
                    else
                        result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }
        public string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken)
        {
            IBucketListData bld = null;
            string[] result = null;

            try
            {
                bld = new BucketListData(Utilities.GetDbSetting());

                string decodedToken = Utilities.DecodeClientBase64String(encodedToken);
                string decodedUserName = Utilities.DecodeClientBase64String(encodedUser);

                //HACK - needed a demo user quick and I didn't want any changes
                if (!string.IsNullOrEmpty(decodedUserName) && decodedUserName.Equals("demouser"))
                {
                    result = Utilities.GetValidTokenResponse();
                }
                else
                {
                    if (ProcessToken(decodedUserName, decodedToken))
                    {
                        bld.DeleteBucketListItem(bucketListDbId);
                        result = Utilities.GetValidTokenResponse();
                    }
                    else
                        result = Utilities.GetInValidTokenResponse();
                }
            }
            catch (Exception e)
            {
                bld.LogMsg("Error: " + e.Message + ", trace: " + e.StackTrace.ToString());
            }

            return result;
        }

        #region Private Methods

        private string VerifyUser(string userName, string password, IMemberShipData msd)
        {
            string token = string.Empty;
            User u = msd.GetUser(userName);

            if (u != null)
            {
                PasswordHelper p = new PasswordHelper();

                bool goodUser = p.UserExists(u, password);

                if (goodUser)
                    token = Utilities.GenerateToken();
            }

            return token;
        }
        private bool ProcessToken(string userName, string token)
        {
            bool goodToken = false;
            IMemberShipData msd = new MemberShipData(Utilities.GetDbSetting());
            User u = msd.GetUser(userName);

            //HACK for android
            token = token.Replace("\"", "");

            if (u != null
                    && !string.IsNullOrEmpty(u.Token)
                        && !string.IsNullOrEmpty(token)
                            && u.Token.Equals(token))
            {
                byte[] data = Convert.FromBase64String(token);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                DateTime now = DateTime.UtcNow.AddHours(-2);
                if (when >= now)
                {
                    goodToken = true;
                }
            }

            return goodToken;
        }

        #endregion
    }
}
