using Shared.misc;

namespace Shared.interfaces
{
    public interface ITgimbaService
    {
        string GetTestResult();
        string ProcessUser(string encodedUser, string encodedPass);
        bool ProcessUserRegistration(string encodedUser, string encodedEmail, string encodedPass);
        string[] GetBucketListItems(string encodedUserName, string encodedSortString, string encodedToken);
        string[] GetBucketListItemsV2(string encodedUserName, string encodedSortString, string encodedToken);
        string[] UpsertBucketListItem(string encodedBucketListItems, string encodedUser, string encodedToken);
        string[] UpsertBucketListItemV2(string encodedBucketListItems, string encodedUser, string encodedToken);
        string[] DeleteBucketListItem(int bucketListDbId, string encodedUser, string encodedToken);
        string[] GetDashboard();
        string LoginDemoUser();

        void Log(string msg, Enums.LogLevel level);
    }
}
