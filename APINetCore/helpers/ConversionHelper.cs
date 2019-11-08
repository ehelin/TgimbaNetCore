using System;
using Shared.dto;
using Shared.interfaces;
using Shared;

namespace BLLNetCore.helpers
{
    public class ConversionHelper : IConversion
    {
        public BucketListItem GetBucketListItem(string[] bucketListItemArray)
        {
            BucketListItem bucketListItem = null;

            // TODO - remove username from string[]...we apparently do not need it
            if (bucketListItemArray != null && bucketListItemArray.Length == Constants.BUCKET_LIST_ITEM_STANDARD_ARRAY_SIZE)  
            {
                bucketListItem = new BucketListItem();

                bucketListItem.Name = bucketListItemArray[0];
                bucketListItem.Created = this.GetSafeDateTime(bucketListItemArray[1]);      //date
                bucketListItem.Category = bucketListItemArray[2];
                
                if (!string.IsNullOrEmpty(bucketListItemArray[3]) && bucketListItemArray[3].Equals("1"))
                    bucketListItem.Achieved = true;

                bucketListItem.Latitude = this.GetSafeDecimal(bucketListItemArray[4]);
                bucketListItem.Longitude = this.GetSafeDecimal(bucketListItemArray[5]);

                if (!string.IsNullOrEmpty(bucketListItemArray[6]))
                    bucketListItem.Id = this.GetSafeInt(bucketListItemArray[6]);
            }

            return bucketListItem;
        }
        public bool GetSafeBool(object val)
        {
            bool result = false;

            if (val != DBNull.Value && val != null)
                result = Convert.ToBoolean(val);

            return result;
        }
        public decimal GetSafeDecimal(object val)
        {
            decimal result = 0;

            if (val != DBNull.Value && val != null)
                result = Convert.ToDecimal(val);

            return result;
        }
        public int GetSafeInt(object val)
        {
            int result = 0;

            if (val != DBNull.Value && val != null && !string.IsNullOrEmpty(val.ToString()))
                result = Convert.ToInt32(val);

            return result;
        }
        public string GetSafeString(object val)
        {
            string result = string.Empty;

            if (val != DBNull.Value && val != null)
                result = Convert.ToString(val);

            return result;
        }
        public DateTime GetSafeDateTime(object val)
        {
            DateTime result = DateTime.MinValue;

            if (val != DBNull.Value && val != null)
                result = Convert.ToDateTime(val);

            return result;
        }
    }
}
