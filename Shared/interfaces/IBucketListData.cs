using System.Collections.Generic;
using Shared.dto;

namespace Shared.interfaces
{
    public interface IBucketListData
    {
        string[] GetBucketList(string userName, string sortString);
        bool UpsertBucketListItem(string[] bucketListItems);
        bool DeleteBucketListItem(int bucketListItemDbId);
        void LogMsg(string msg);
        string[] GetDashboard();

        string[] GetBucketListV2(string userName, string sortString, string srchTerm = "");
        bool UpsertBucketListItemV2(string[] bucketListItems);
        string GetReport();
        List<SystemStatistic> GetSystemStatistics();
        List<SystemBuildStatistic> GetSystemBuildStatistics();
    }
}
