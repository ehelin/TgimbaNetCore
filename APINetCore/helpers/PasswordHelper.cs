using System.Security.Cryptography;
using Shared;
using System;
using Shared.interfaces;
using Shared.dto;
using System.Text;

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

        public string GetSalt()
        {
            // TODO - update with latest/greatest after research...this is probably dated
            throw new NotImplementedException();
            //RNGCryptoServiceProvider saltGen = null;
            //string salt = string.Empty;

            //try
            //{
            //    saltGen = new RNGCryptoServiceProvider();
            //    byte[] buffer = new byte[Constants.SALT_SIZE];
            //    saltGen.GetBytes(buffer);
            //    salt = Convert.ToBase64String(buffer);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            //finally
            //{
            //    if (saltGen != null)
            //    {
            //        saltGen.Dispose();
            //        saltGen = null;
            //    }
            //}

            //return salt;
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
    }
}
