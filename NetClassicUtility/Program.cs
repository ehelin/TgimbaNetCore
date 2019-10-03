using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NetClassicUtility
{
    class Program
    {
        public static void Main(string[] args)
        {
            var rsaPrivateKey = GetPrivateKey();
        }

        public static string GetPrivateKey()
        {
            RSA rsa = new RSACryptoServiceProvider(2048); // Generate a new 2048 bit RSA key

            string key = rsa.ToXmlString(true);

            return key;
        }
    }
}