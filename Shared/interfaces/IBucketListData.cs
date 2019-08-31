using System.Collections.Generic;
using Shared.dto;

namespace Shared.interfaces
{
    public interface IBucketListData
    {
        IList<Shared.dto.BucketListItem> GetBucketList(string userName, string sortColumn, bool isAsc = true, string srchTerm = "");
        void UpsertBucketListItem(Shared.dto.BucketListItem bucketListItem, string userName);
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
