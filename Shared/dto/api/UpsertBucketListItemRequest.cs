namespace Shared.dto.api
{
    public class UpsertBucketListItemRequest
    {
        public TokenRequest Token { get; set; }
        public BucketListItem BucketListItem { get; set; }
    }
}
