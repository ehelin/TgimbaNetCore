using System.Collections.Generic;
using Shared.dto;

namespace Shared.interfaces
{
    public interface IBucketListData
    {
        IList<BucketListItem> GetBucketList(string userName, string sortString, string srchTerm = "");
        void UpsertBucketListItem(BucketListItem bucketListItems);
        void DeleteBucketListItem(int bucketListItemDbId);
        void LogMsg(string msg);
        IList<SystemStatistic> GetSystemStatistics();
        IList<SystemBuildStatistic> GetSystemBuildStatistics();

        User GetUser(string userName);
        void AddUser(string userName, string email, string passWord, string salt);
        void DeleteUser(string userName, string passWord, string email);
        void AddToken(string userName, string token);
    }
}
