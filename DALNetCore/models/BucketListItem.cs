using System;
using System.Collections.Generic;

namespace DALNetCore.Models
{
    public partial class BucketListItem
    {
        public int BucketListItemId { get; set; }
        public string ListItemName { get; set; }
        public DateTime? Created { get; set; }
        public string Category { get; set; }
        public bool? Achieved { get; set; }
        public int? CategorySortOrder { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        //cpublic string Country { get; set; }
    }
}
