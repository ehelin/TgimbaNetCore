namespace Shared.dto.api
{
    public class DeleteBucketListItemRequest
    {
        public TokenRequest Token { get; set; }
        public int BucketListItemId { get; set; }
    }
}
