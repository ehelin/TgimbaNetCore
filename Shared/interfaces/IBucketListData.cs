using System.Collections.Generic;
using Shared.dto;

namespace Shared.interfaces
{
    public interface IBucketListData
    {
        IList<BucketListItem> GetBucketList(string userName, string sortString, string srchTerm = "");
        bool UpsertBucketListItem(BucketListItem bucketListItems);
        bool DeleteBucketListItem(int bucketListItemDbId);
        void LogMsg(string msg);
        IList<SystemStatistic> GetSystemStatistics();
        IList<SystemBuildStatistic> GetSystemBuildStatistics();

        User GetUser(string userName);
        bool AddUser(string userName, string email, string passWord, string salt);
        bool DeleteUser(string userName, string passWord, string email);
        void AddToken(string userName, string token);
    }
}
