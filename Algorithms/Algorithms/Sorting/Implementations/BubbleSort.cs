using System;
using Shared.dto;
using Shared.misc;
using System.Collections.Generic;

namespace Algorithms.Algorithms.Sorting.Implementations
{
    public class BubbleSort : ISort
    {
        public List<BucketListItem> Sort(List<BucketListItem> values, Enums.SortColumns sortColumn, bool desc)
        {
            List<BucketListItem> sortedValues = null;

            for(int outer=0; outer<values.Count; outer++)
            {
                for (int inner=0; inner<values.Count; inner++)
                {
                    if (inner + 1 >= values.Count) { break; }

                    if (sortColumn == Enums.SortColumns.ListItemName) { sortedValues = SortName(inner, inner+1, values, desc); }
                    //if (sortColumn == Enums.SortColumns.Achieved) { sortedValues = SortAchieved(values); }
                    //if (sortColumn == Enums.SortColumns.Category) { sortedValues = SortName(values); }
                    //if (sortColumn == Enums.SortColumns.Created) { sortedValues = SortName(values); }
                }
            }

            return sortedValues;
        }
        
        private List<BucketListItem> SortName(int outer, int innerPlusOne, List<BucketListItem> values, bool desc)
        {
            var innerCompare = Convert.ToChar(values[outer].Name.ToLower().Substring(0, 1));
            var innerPlusOneCompare = Convert.ToChar(values[innerPlusOne].Name.ToLower().Substring(0, 1));
            bool swap = !desc && innerCompare > innerPlusOneCompare;

            if (!swap)
            {
                 swap = desc && innerCompare < innerPlusOneCompare;
            }

            if (swap)
            {
                var tmp = values[outer];
                values[outer] = values[innerPlusOne];
                values[innerPlusOne] = tmp;
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
