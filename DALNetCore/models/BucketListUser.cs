namespace DALNetCore.Models
{
    public partial class BucketListUser
    {
        public int BucketListUserId { get; set; }
        public int? BucketListItemId { get; set; }
        public int? UserId { get; set; }
    }
}
