using System.Collections.Generic;
using Shared.dto;
using Shared.misc;

namespace Algorithms.Algorithms.Search
{
    public interface ISearch
    {
        IList<BucketListItem> Search(IList<BucketListItem> bucketListItems, string srchTerm);
        Enums.SearchAlgorithms GetSearchingAlgorithm();
    }
}
