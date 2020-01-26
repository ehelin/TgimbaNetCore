using System.Collections.Generic;
using System.Linq;
using Shared.dto;
using Shared.misc;

namespace Algorithms.Algorithms.Sorting.Implementations
{
    public class LinqSort : ISort
    {
        public List<BucketListItem> Sort(IList<BucketListItem> values, Enums.SortColumns sortColumn, bool desc)
        {
            List<BucketListItem> sortedBucketListItems = null;

            // NOTE: Unknown sort column types handled at service level
            if (sortColumn == Enums.SortColumns.ListItemName)
            {
                if (!desc)
                {
                    sortedBucketListItems = values.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    sortedBucketListItems = values.OrderByDescending(x => x.Name).ToList();
                }
            }
            else if (sortColumn == Enums.SortColumns.Created)
            {
                if (!desc)
                {
                    sortedBucketListItems = values.OrderBy(x => x.Created).ToList();
                }
                else
                {
                    sortedBucketListItems = values.OrderByDescending(x => x.Created).ToList();
                }
            }
            else if (sortColumn == Enums.SortColumns.Category)
            {
                if (!desc)
                {
                    sortedBucketListItems = values.OrderBy(x => x.Category).ToList();
                }
                else
                {
                    sortedBucketListItems = values.OrderByDescending(x => x.Category).ToList();
                }
            }
            else if (sortColumn == Enums.SortColumns.Achieved)
            {
                if (!desc)
                {
                    sortedBucketListItems = values.OrderBy(x => x.Achieved).ToList();
                }
                else
                {
                    sortedBucketListItems = values.OrderByDescending(x => x.Achieved).ToList();
                }
            }

            return sortedBucketListItems;
        }
    }
}
