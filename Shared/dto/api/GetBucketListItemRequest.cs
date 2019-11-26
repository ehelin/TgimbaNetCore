namespace Shared.dto.api
{
    public class GetBucketListItemRequest
    {
        public TokenRequest Token { get; set; }
        public string EncodedSortString { get; set; }
        public string EncodedSearchString { get; set; }
    }
}
