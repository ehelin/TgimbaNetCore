using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.interfaces;
using Shared.misc;

namespace APINetCore
{
    public class TgimbaService : ITgimbaService
    {
        public string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken)
        {
            throw new NotImplementedException();
        }

        public string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken)
        {
            throw new NotImplementedException();
        }

        public string[] GetBucketListItemsV2(string encodedUserName, string encodedSortString, string encodedToken, string encodedSrchString = "")
        {
            throw new NotImplementedException();
        }

        public string[] GetDashboard()
        {
            throw new NotImplementedException();
        }

        public string GetReport()
        {
            throw new NotImplementedException();
        }

        public List<SystemBuildStatistic> GetSystemBuildStatistics()
        {
            throw new NotImplementedException();
        }

        public List<SystemStatistic> GetSystemStatistics()
        {
            throw new NotImplementedException();
        }

        public string GetTestResult()
        {
            throw new NotImplementedException();
        }

        public void Log(string msg, Enums.LogLevel level)
        {
            throw new NotImplementedException();
        }

        public string LoginDemoUser()
        {
            throw new NotImplementedException();
        }

        public string ProcessUser(string encodedUser, string encodedPass)
        {
            throw new NotImplementedException();
        }

        public bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass)
        {
            throw new NotImplementedException();
        }

        public string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            throw new NotImplementedException();
        }

        public string[] UpsertBucketListItemV2(string encodedBucketListItems, string encodedUser, string encodedToken)
        {
            throw new NotImplementedException();
        }
    }
}
