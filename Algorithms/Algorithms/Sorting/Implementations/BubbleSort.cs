using System;
using Shared.dto;
using Shared.misc;
using System.Collections.Generic;

namespace Algorithms.Algorithms.Sorting.Implementations
{
    public class BubbleSort : ISort
    {
        public List<BucketListItem> Sort(List<BucketListItem> values, Enums.SortColumns sortColumn)
        {
            List<BucketListItem> sortedValues = null;

            for(int outer=0; outer<values.Count; outer++)
            {
                for(int inner=outer; inner<values.Count; inner++)
                {
                    if (inner+1 >= values.Count) { break; }

                    if (sortColumn == Enums.SortColumns.ListItemName) { sortedValues = SortName(inner, inner + 1, values); }
                    //if (sortColumn == Enums.SortColumns.Achieved) { sortedValues = SortAchieved(values); }
                    //if (sortColumn == Enums.SortColumns.Category) { sortedValues = SortName(values); }
                    //if (sortColumn == Enums.SortColumns.Created) { sortedValues = SortName(values); }
                }

                outer++;
            }

            return sortedValues;
        }

        private List<BucketListItem> SortName(int inner, int innerPlusOne, List<BucketListItem> values)
        {
            int innerCompare = Convert.ToChar(values[inner].Name.ToLower().Substring(0, 1));
            int innerPlusOneCompare = Convert.ToChar(values[innerPlusOne].Name.ToLower().Substring(0, 1));

            if (innerCompare > innerPlusOneCompare)
            {
                var swap = values[inner];
                values[inner] = values[innerPlusOne];
                values[innerPlusOne] = swap;
            }

            return values;
        }

        //private BucketListItem[] SortAchieved(BucketListItem inner1, BucketListItem inner2)
        //{
        //    // TODO - implement

        //    return values;
        //}

        //private BucketListItem[] SortCategory(BucketListItem[] values)
        //{
        //    // TODO - implement

        //    return values;
        //}

        //private BucketListItem[] SortCreated(BucketListItem[] values)
        //{
        //    // TODO - implement

        //    return values;
        //}
    }
}
