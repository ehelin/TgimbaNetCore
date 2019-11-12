using Shared.dto;
using System;

namespace Shared.interfaces
{
    public interface IConversion
    {
        //BucketListItem GetBucketListItem(string[] bucketListItemArray);
        bool GetSafeBool(object val);
        decimal GetSafeDecimal(object val);
        int GetSafeInt(object val);
        string GetSafeString(object val);
        DateTime GetSafeDateTime(object val);
    }
}
