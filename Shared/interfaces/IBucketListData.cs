namespace Shared.interfaces
{
    public interface IBucketListData
    {
        string[] GetBucketList(string userName, string sortString);
        bool UpsertBucketListItem(string[] bucketListItems);
        bool DeleteBucketListItem(int bucketListItemDbId);
        void LogMsg(string msg);
        string[] GetDashboard();

        string[] GetBucketListV2(string userName, string sortString);
        bool UpsertBucketListItemV2(string[] bucketListItems);
    }
}
