using System;
using System.Text;
using Shared.interfaces;
using Shared.dto;

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

        public BucketListItem GetBucketListItem(string[] bucketListItemArray)
        {
            BucketListItem bucketListItem = null;

            // TODO - remove username from string[]...we apparently do not need it
            if (bucketListItemArray != null && bucketListItemArray.Length == 7)  // TODO - make a constant (verify its seven)
            {
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

                protected bool GetSafeBool(object val)
        {
            bool result = false;

            if (val != DBNull.Value && val != null)
                result = Convert.ToBoolean(val);

            return result;
        }
        protected decimal GetSafeDecimal(object val)
        {
            decimal result = 0;

            if (val != DBNull.Value && val != null)
                result = Convert.ToDecimal(val);

            return result;
        }
        // TODO - take these methods and create a Conversions Class...
        //protected int GetSafeInt(object val)
        //{
        //    int result = 0;

        //    if (val != DBNull.Value && val != null && !string.IsNullOrEmpty(val.ToString()))
        //        result = Convert.ToInt32(val);

        //    return result;
        //}
        //protected string GetSafeString(object val)
        //{
        //    string result = string.Empty;

        //    if (val != DBNull.Value && val != null)
        //        result = Convert.ToString(val);

        //    return result;
        //}
        //protected DateTime GetSafeDateTime(object val)
        //{
        //    DateTime result = DateTime.MinValue;

        //    if (val != DBNull.Value && val != null)
        //        result = Convert.ToDateTime(val);

        //    return result;
        //}
    }
}
