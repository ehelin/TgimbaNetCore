using System.Security.Cryptography;
using Shared;

namespace BLLNetCore.Security
{
    public class Generator
    {
        public string GetPrivateKey() 
        {
            // TODO - re test this after .net core 3 is installed
            //RSA rsa = new RSACryptoServiceProvider(2048); // Generate a new 2048 bit RSA key
            //string key = rsa.ToXmlString(true);

            //NOTE: Temporary key generated from NetClassicUtility...replace when .net core has 
            //      same functionality as .Net Classic
            string key = Credentials.GetPrivateKey();

            return key;
        }
    }
}
