using System.Collections.Generic;
using Shared.dto;

namespace Algorithms.Algorithms.Search
{
    public interface ISearch
    {
        IList<BucketListItem> Search(IList<BucketListItem> bucketListItems, string srchTerm);
    }
}
