using System;
using System.Text;
using Shared.interfaces;
using Shared.misc;

namespace BLLNetCore.helpers
{
    public class StringHelper : IString
    {
        public string DecodeBase64String(string val)
        {
            string decodedString = string.Empty;

            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = Convert.FromBase64String(val);
                decodedString = Encoding.UTF8.GetString(data);
            }

            return decodedString;
        }

        public string EncodeBase64String(string val)
        {
            string encodedString = string.Empty;

            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(val);
                encodedString = Convert.ToBase64String(data);
            }

            return encodedString;
        }

        public bool HasSortOrderAsc(string sortString)
        {
            bool isAscOrder = false;

            if (!string.IsNullOrEmpty(sortString))
            {
                var sortStringToLower = GetLowerCaseSortString(sortString);

                if (sortStringToLower.IndexOf("asc") != -1)
                {
                    isAscOrder = true;
                }
            }

            return isAscOrder;
        }

        public string GetLowerCaseSortString(string sortString)
        {
            var sortStringToLower = string.Empty;

            if (!string.IsNullOrEmpty(sortString))
            {
                sortStringToLower = sortString.ToLower();
            }
        
            return sortStringToLower;
        }

        // TODO - add test
        public Enums.SortColumns GetSortColumn(string sortString)
        {
            var sortStringToLower = GetLowerCaseSortString(sortString);

            if (sortStringToLower.IndexOf(Enums.SortColumns.ListItemName.ToString().ToLower()) != -1)
            {
                return Enums.SortColumns.ListItemName;
            }
            else if (sortStringToLower.IndexOf(Enums.SortColumns.Created.ToString().ToLower()) != -1)
            {
                return Enums.SortColumns.Created;
            }
            else if (sortStringToLower.IndexOf(Enums.SortColumns.Category.ToString().ToLower()) != -1)
            {
                return Enums.SortColumns.Category;
            }
            else if (sortStringToLower.IndexOf(Enums.SortColumns.Achieved.ToString().ToLower()) != -1)
            {
                return Enums.SortColumns.Achieved;
            }
            else
            {
                throw new ArgumentException("Unknown sort string - " + sortString);
            }
        }
    }
}
