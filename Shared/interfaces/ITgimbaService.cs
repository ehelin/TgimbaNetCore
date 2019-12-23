using Shared.misc;
using System.Collections.Generic;
using Shared.dto;

using Shared.dto;

namespace Shared.interfaces
{
    public interface ITgimbaService
    {
        string ProcessUser(string encodedUser, string encodedPass);
        bool ProcessUserRegistration(string encodedUserName, string encodedEmail, string encodedPassword);

        IList<BucketListItem> GetBucketListItems(string encodedUserName, string encodedSortString, 
											string encodedToken, string encodedSrchString = "");
        bool UpsertBucketListItem(BucketListItem bucketListItem, string encodedUser, string encodedToken);
        bool DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken);
 
        IList<SystemStatistic> GetSystemStatistics(string encodedUser, string encodedToken);
        IList<SystemBuildStatistic> GetSystemBuildStatistics(string encodedUser, string encodedToken);
        void LogAuthenticated(string msg, string encodedUser, string encodedToken);
        void Log(string msg);
        string LoginDemoUser();
        string GetTestResult();
    }
}
