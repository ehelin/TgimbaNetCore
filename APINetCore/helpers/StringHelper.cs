using System;
using System.Text;
using Shared.interfaces;

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
    }
}
