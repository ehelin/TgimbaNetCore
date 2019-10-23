using System;
using System.Security.Cryptography;
using System.Text;
using Shared;
using Shared.dto;
using Shared.interfaces;
using System.Linq;

namespace BLLNetCore.Security
{
    public class PasswordHelper : IPassword
    {
        public bool PasswordsMatch(Password passwordDto, User user)
        {
            bool passwordsMatch = false;

            if (user.Password.Equals(passwordDto.SaltedHashedPassword))
                passwordsMatch = true;

            return passwordsMatch;
        }

        public string GetSalt(int size)
        {
            var saltGen = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[size];
            saltGen.GetNonZeroBytes(buffer);
            var salt = Convert.ToBase64String(buffer);

            return salt;
        }

        public Password HashPassword(Password passwordDto)
        {
            byte[] bytePassword = Encoding.UTF8.GetBytes(passwordDto.GetPassword());
            byte[] byteSalt = Encoding.UTF8.GetBytes(passwordDto.Salt);
            byte[] bytesHash;

            using (var deriveBytes = new Rfc2898DeriveBytes(bytePassword, byteSalt, Constants.HASH_ITERATIONS, HashAlgorithmName.SHA256))
            {
                bytesHash = deriveBytes.GetBytes(Constants.KEY_LENGTH);
            }
            passwordDto.SaltedHashedPassword = Convert.ToBase64String(bytesHash);            

            return passwordDto;
        }
        
        public bool ContainsOneNumber(string password)
        {
            char[] charArray = password.ToArray();
            var numberFound = false;

            for (var i = 0; i < charArray.Length; i++)
            {
                string curChar = charArray[i].ToString();

                int j;
                if (Int32.TryParse(curChar, out j))
                {
                    numberFound = true;
                    break;
                }
            }

            return numberFound;
        }
    }
}
