using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.misc;

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
                    long innerCompare = 0;
                    long innerPlusOneCompare = 0;

                    if (sortColumn == Enums.SortColumns.ListItemName) { SortName(inner, inner+1, values, out innerCompare, out innerPlusOneCompare); }
                    if (sortColumn == Enums.SortColumns.Created) { SortCreated(inner, inner + 1, values, out innerCompare, out innerPlusOneCompare); }
                    if (sortColumn == Enums.SortColumns.Category) { SortCategory(inner, inner + 1, values, out innerCompare, out innerPlusOneCompare); }
                    if (sortColumn == Enums.SortColumns.Achieved) { SortAchieved(inner, inner + 1, values, out innerCompare, out innerPlusOneCompare); }

                    if (ifSwapValues(desc, innerCompare, innerPlusOneCompare))
                    {
                        var tmp = values[inner];
                        values[inner] = values[inner + 1];
                        values[inner + 1] = tmp;
                    }
                }
            }

            return values;
        }

        private bool ifSwapValues(bool desc, long innerCompare, long innerPlusOneCompare)
        {
            bool swap = !desc && innerCompare > innerPlusOneCompare;

            if (!swap)
            {
                swap = desc && innerCompare < innerPlusOneCompare;
            }

            return swap;
        }
        
        private void SortName
        (
            int inner, 
            int innerPlusOne, 
            List<BucketListItem> values, 
            out long innerCompare, 
            out long innerPlusOneCompare
        ) {
            innerCompare = Convert.ToChar(values[inner].Name.ToLower().Substring(0, 1));
            innerPlusOneCompare = Convert.ToChar(values[innerPlusOne].Name.ToLower().Substring(0, 1));
        }

        private void SortCreated
        (
            int inner,
            int innerPlusOne,
            List<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            innerCompare = long.Parse(values[inner].Created.ToString("yyyyMMddHHmmss"));
            innerPlusOneCompare = long.Parse(values[innerPlusOne].Created.ToString("yyyyMMddHHmmss"));
        }

        private void SortCategory
        (
            int inner,
            int innerPlusOne,
            List<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            innerCompare = Convert.ToChar(values[inner].Category.ToLower().Substring(0, 1));
            innerPlusOneCompare = Convert.ToChar(values[innerPlusOne].Category.ToLower().Substring(0, 1));
        }

        private void SortAchieved
        (
            int inner,
            int innerPlusOne,
            List<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            innerCompare = Convert.ToInt64(values[inner].Achieved);
            innerPlusOneCompare = Convert.ToInt64(values[innerPlusOne].Achieved);
        }
    }
}
