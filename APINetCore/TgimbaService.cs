using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Algorithms.Algorithms.Sorting;
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
        private IAvailableSortingAlgorithms availableSortingAlgorithms = null;
        private IAvailableSearchingAlgorithms availableSearchingAlgorithms = null;

        public TgimbaService
        (
            IBucketListData bucketListData, 
            IPassword passwordHelper, 
            IGenerator generatorHelper,
            IString stringHelper,
            IAvailableSortingAlgorithms availableSortingAlgorithms,
            IAvailableSearchingAlgorithms availableSearchingAlgorithms
        ) {
            this.bucketListData = bucketListData;
            this.passwordHelper = passwordHelper;
            this.generatorHelper = generatorHelper;
            this.stringHelper = stringHelper;
            this.availableSortingAlgorithms = availableSortingAlgorithms;
            this.availableSearchingAlgorithms = availableSearchingAlgorithms;
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

                if (!passwordsMatch)
                {
                    // NOTE: Legacy user passwords where hashed with another algorithm - TODO - update users
                    hashedPassword.SaltedHashedPassword = this.HashPasswordLegacy(user.Salt, decodedPassword);
                    passwordsMatch = this.passwordHelper.PasswordsMatch(hashedPassword, user);
                }

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

        public bool DeleteBucketListItem
        (
            int bucketListDbId//, 
            //string encodedUser, 
            //string encodedToken
        ) {
            bool bucketListItemDeleted = false;

            //if (this.IsValidToken(encodedUser, encodedToken))
            //{
                this.bucketListData.DeleteBucketListItem(bucketListDbId);
                bucketListItemDeleted = true;
            //}

            return bucketListItemDeleted;
        }
        
        public IList<BucketListItem> GetBucketListItems
        (
            string encodedUserName, 
            string encodedSortString, 
            string encodedToken, 
            string encodedSrchString = "",
            string encodedSortType = "",
            string encodedSearchType = ""
        ) {
            IList <BucketListItem> bucketListItems = null;

            string decodedSortString = this.stringHelper.DecodeBase64String(encodedSortString);
            string decodedSortType = this.stringHelper.DecodeBase64String(encodedSortType);
            string decodedSrchString = this.stringHelper.DecodeBase64String(encodedSrchString);
            string decodedSrchType = this.stringHelper.DecodeBase64String(encodedSearchType);

            if (this.IsValidToken(encodedUserName, encodedToken))
            {               
                bucketListItems = this.bucketListData.GetBucketList(this.stringHelper.DecodeBase64String(encodedUserName));

                if (!string.IsNullOrEmpty(decodedSortString))
                {
                    bucketListItems = Sort(bucketListItems,decodedSortString, decodedSortType);
                }

                if (!string.IsNullOrEmpty(decodedSrchString))
                {
                    bucketListItems = Search(bucketListItems, decodedSrchString, decodedSrchType);
                }
            }

            return bucketListItems;
        }

        private IList<BucketListItem> Search
        (
          IList<BucketListItem> bucketListItems,
          string decodedSrchString,
          string decodedSrchType
        )
        {
            Enums.SearchAlgorithms selectedSearchAlgorithm = (Enums.SearchAlgorithms)Enum.Parse(typeof(Enums.SearchAlgorithms), decodedSrchType);
            var searchAlgorithm = availableSearchingAlgorithms.GetAlgorithm(selectedSearchAlgorithm);

            bucketListItems = searchAlgorithm.Search(bucketListItems, decodedSrchString);

            return bucketListItems;
        }

        private IList<BucketListItem> Sort
        (
            IList<BucketListItem> bucketListItems, 
            string decodedSortString, 
            string decodedSortType
        ) {
            var sortColumn = this.stringHelper.GetSortColumn(decodedSortString);
            var sortAsc = this.stringHelper.HasSortOrderAsc(decodedSortString);
            Enums.SortAlgorithms selectedSortAlgorithm = (Enums.SortAlgorithms)Enum.Parse(typeof(Enums.SortAlgorithms), decodedSortType);
            var sortAlgorithm = availableSortingAlgorithms.GetAlgorithm(selectedSortAlgorithm);

            try 
            {
                bucketListItems = sortAlgorithm.Sort(bucketListItems, sortColumn, !sortAsc);
            } 
            catch(Exception ex)
            {
                Log("Sort failed - Error: " + ex.Message);
            }
            
            return bucketListItems;
        }

        public bool UpsertBucketListItem
        (
            BucketListItem bucketListItem, 
            string encodedUser, 
            string encodedToken
        ) {
            // TODO - handle demo user at client so they cannot upsert values
            bool goodUpsert = false;
            
            if (this.IsValidToken(encodedUser, encodedToken))
            {
                this.bucketListData.UpsertBucketListItem(bucketListItem, this.stringHelper.DecodeBase64String(encodedUser));
                goodUpsert = true;
            }          

            return goodUpsert;
        }

        #endregion

        #region Misc
    
        public IList<SystemBuildStatistic> GetSystemBuildStatistics(string encodedUser, string encodedToken)
        {
            IList<SystemBuildStatistic> systemBuildStatistics = null;

            if (this.IsValidToken(encodedUser, encodedToken))
            {
                systemBuildStatistics = this.bucketListData.GetSystemBuildStatistics();
            }

            return systemBuildStatistics;
        }

        public IList<SystemStatistic> GetSystemStatistics(string encodedUser, string encodedToken)
        {
            IList<SystemStatistic> systemBuildStatistics = null;
            
            if (this.IsValidToken(encodedUser, encodedToken))
            {
                systemBuildStatistics = this.bucketListData.GetSystemStatistics();
            }
            
            return systemBuildStatistics;
        }

        // TODO - verify you have added tests for...
        public void LogAuthenticated(string msg, string encodedUser, string encodedToken)
        {
            if (this.IsValidToken(encodedUser, encodedToken))
            {
                this.Log(msg);
            }
        }

        // TODO - verify you have added tests for...
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

        #region Private Methods

        private bool IsValidToken(string encodedUser, string encodedToken)
        {
            string decodedUserName = this.stringHelper.DecodeBase64String(encodedUser);
            string decodedToken = this.stringHelper.DecodeBase64String(encodedToken);

            var user = this.bucketListData.GetUser(decodedUserName);
            var validToken = this.passwordHelper.IsValidToken(user, decodedToken);

            return validToken;
        }

        private string HashPasswordLegacy(string salt, string password)
        {
            HashAlgorithm hashAlg = null;
            string hashedPassword = null;

            try
            {
                hashAlg = new SHA256CryptoServiceProvider();
                var saltAndPassword = salt + password;
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(saltAndPassword);
                byte[] bytHash = hashAlg.ComputeHash(bytValue);
                hashedPassword = Convert.ToBase64String(bytHash);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (hashAlg != null)
                {
                    hashAlg.Clear();
                    hashAlg.Dispose();
                    hashAlg = null;
                }
            }

            return hashedPassword;
        }

        #endregion
    }
}
