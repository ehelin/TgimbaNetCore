using System;
using Shared.interfaces;

namespace BLLNetCore.helpers
{
    public class ConversionHelper : IConversion
    {
        // TODO - decide if we need these conversion methods...without string arrays, I think we many not...
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
