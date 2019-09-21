using Shared.misc;
using System.Collections.Generic;
using Shared.dto;

namespace Shared.interfaces
{
    public interface ITgimbaService
    {
        string ProcessUser(string encodedUser, string encodedPass);
        bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass);

        string[] GetBucketListItems(string encodedUserName, string encodedSortString, 
											string encodedToken, string encodedSrchString = "");
        string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken);
        string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken);
 
        IList<SystemStatistic> GetSystemStatistics();
        IList<SystemBuildStatistic> GetSystemBuildStatistics();
        void Log(string msg);
        string LoginDemoUser();
    }
}
