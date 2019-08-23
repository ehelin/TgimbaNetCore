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

        void AddToken(int userId, string token);
        User GetUser(int id);
        int AddUser(User user);
        void DeleteUser(int userId);
    }
}
