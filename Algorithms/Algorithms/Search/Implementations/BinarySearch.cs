using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.misc;

namespace Algorithms.Algorithms.Search.Implementations
{
    public class BinarySearch : ISearch
    {
        public Enums.SearchAlgorithms GetSearchingAlgorithm()
        {
            return Enums.SearchAlgorithms.Binary;
        }

        public IList<BucketListItem> Search(IList<BucketListItem> bucketListItems, string srchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
