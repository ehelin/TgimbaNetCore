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

            // TODO - sort bucket list items by name
            // TODO - use bubble sort
            // TODO - use insertion sort
            // TODO - use linq sort
            
            // TODO - take search term and use algorithm to find

            // TODO - include multiple results (ideally, this would be just testing boundaries until srch term doesn't exist going up and down)

        }
    }
}
