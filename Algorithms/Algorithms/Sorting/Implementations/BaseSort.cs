using System;
using System.Collections.Generic;
using Shared.dto;

namespace Algorithms.Algorithms.Sorting.Implementations
{
    public class BaseSort
    {
        protected void SortName
        (
            int inner,
            int innerPlusOne,
            IList<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            var innerCompareArray = values[inner].Name.Split(" ");
            var innerPlusOneCompareArray = values[innerPlusOne].Name.Split(" ");
            var shorterBucketListItemArray = innerCompareArray.Length < innerPlusOneCompareArray.Length
                                            ? innerCompareArray : innerPlusOneCompareArray;
            innerCompare = 0;
            innerPlusOneCompare = 0;

            for (var i = 0; i < shorterBucketListItemArray.Length; i++)
            {
                // if empty string, skip to next term...cannot convert "" to a char ;)
                if (innerCompareArray[i] == "" || innerPlusOneCompareArray[i] == "") { continue; }

                var innerCompareCurrent = Convert.ToChar(innerCompareArray[i].ToLower().Substring(0, 1));
                var innerPlusOneCompareCurrent = Convert.ToChar(innerPlusOneCompareArray[i].ToLower().Substring(0, 1));

                if (innerCompareCurrent != innerPlusOneCompareCurrent)
                {
                    innerCompare = innerCompareCurrent;
                    innerPlusOneCompare = innerPlusOneCompareCurrent;
                    break;
                }
            }

            // TODO - update tests to handle and fail gracefully...
            if (innerCompare == 0 && innerPlusOneCompare == 0)
            {
                throw new Exception("Name sort cannot sort list");
            }
        }

        protected void SortCreated
        (
            int inner,
            int innerPlusOne,
            IList<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            innerCompare = long.Parse(values[inner].Created.ToString("yyyyMMddHHmmss"));
            innerPlusOneCompare = long.Parse(values[innerPlusOne].Created.ToString("yyyyMMddHHmmss"));
        }

        protected void SortCategory
        (
            int inner,
            int innerPlusOne,
            IList<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            innerCompare = Convert.ToChar(values[inner].Category.ToLower().Substring(0, 1));
            innerPlusOneCompare = Convert.ToChar(values[innerPlusOne].Category.ToLower().Substring(0, 1));
        }

        protected void SortAchieved
        (
            int inner,
            int innerPlusOne,
            IList<BucketListItem> values,
            out long innerCompare,
            out long innerPlusOneCompare
        )
        {
            innerCompare = Convert.ToInt64(values[inner].Achieved);
            innerPlusOneCompare = Convert.ToInt64(values[innerPlusOne].Achieved);
        }
    }
}
