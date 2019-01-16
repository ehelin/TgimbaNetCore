using System;
using System.Collections.Generic;
using System.Text;

namespace TestsAPIIntegration
{
    public class TestUtilities
	{
		public static  string GetBucketListItemDbId(string singleLineBucketListItem)
        {
            int pos = singleLineBucketListItem.LastIndexOf(',');
            string dbIdStr = singleLineBucketListItem.Substring(pos + 1, singleLineBucketListItem.Length - (pos + 1));

            return dbIdStr;
        }
        public static string GetBucketListItemSingleString(string userName, string listItemName, string dbIdStr, bool extended = false)
        {
            string[] bucketListItem = GetBucketListItem(userName, listItemName, dbIdStr, extended);
            string singleLineBucketListItem = "";

            foreach (string bucketListItemEntry in bucketListItem)
            {
                singleLineBucketListItem += "," + bucketListItemEntry;
            }

            return singleLineBucketListItem;
        }
        public static string[] GetBucketListItem(string userName, string listItemName = "", string dbIdStr = "", bool extended = false)
        {
            string[] bucketListItems;

            if (extended)
            {
                bucketListItems = new string[8];
            }
            else
            {
                bucketListItems = new string[6];
            }

            bucketListItems[0] = listItemName;
            bucketListItems[1] = "12/15/2010";
            bucketListItems[2] = "Hot";
            bucketListItems[3] = "1";

            if (extended) {
                bucketListItems[4] = "123.333";
                bucketListItems[5] = "555.1345";
                bucketListItems[6] = dbIdStr;
                bucketListItems[7] = userName;
            }
            else {
                bucketListItems[4] = dbIdStr;
                bucketListItems[5] = userName;
            }

            return bucketListItems;
        }
	}
}
