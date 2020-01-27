using System.Collections.Generic;
using System.Linq;
using Shared.dto;

namespace Algorithms.Algorithms.Search.Implementations
{
    public class LinqSearch : ISearch
    {
        public IList<BucketListItem> Search(IList<BucketListItem> bucketListItems, string srchTerm)
        {
            var searchedBucketListItems = bucketListItems.Where(x => x.Name.Contains(srchTerm));

            return searchedBucketListItems.ToList();
        }
    }
}
