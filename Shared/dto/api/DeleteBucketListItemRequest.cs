namespace Shared.dto.api
{
    public class DeleteBucketListItemRequest
    {
        public string EncodedUserName { get; set; }
        public string EncodedToken { get; set; }
        public int BucketListItemId { get; set; }
    }
}
