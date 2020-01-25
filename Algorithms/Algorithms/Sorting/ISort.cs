using System.Collections.Generic;
using Shared.dto;
using Shared.misc;

namespace Algorithms.Algorithms.Sorting
{
    public interface ISort
    {
        List<BucketListItem> Sort(List<BucketListItem> values, Enums.SortColumns sortColumn, bool desc);
    }
}
