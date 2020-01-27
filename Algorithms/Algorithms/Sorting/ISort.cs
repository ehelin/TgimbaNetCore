using System.Collections.Generic;
using Shared.dto;
using Shared.misc;

namespace Algorithms.Algorithms.Sorting
{
    public interface ISort
    {
        IList<BucketListItem> Sort(IList<BucketListItem> values, Enums.SortColumns sortColumn, bool desc);
    }
}
