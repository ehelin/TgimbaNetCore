using System.Security.Cryptography;
using Shared;
using System;
using Shared.interfaces;
using Shared.dto;

namespace BLLNetCore.Security
{
    public class PasswordHelper : IPassword
    {
        public bool PasswordsMatch(string suppliedPassword, string dbSalt, string dbPassword)
        {
            bool passwordsMatch = false;
            var np = new Password(suppliedPassword);

            np.Salt = dbSalt;
            np = HashPassword(np);

            if (dbPassword.Equals(np.SaltedHashedPassword))
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

        public Password HashPassword(Password np)
        {
            // TODO - update with latest/greatest after research...this is probably dated
            throw new NotImplementedException();
            //HashAlgorithm hashAlg = null;

            //try
            //{
            //    hashAlg = new SHA256CryptoServiceProvider();
            //    byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(np.GetSaltPassword());
            //    byte[] bytHash = hashAlg.ComputeHash(bytValue);
            //    np.SaltedHashedPassword = Convert.ToBase64String(bytHash);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            //finally
            //{
            //    if (hashAlg != null)
            //    {
            //        hashAlg.Clear();
            //        hashAlg.Dispose();
            //        hashAlg = null;
            //    }
            //}

            //return np;
        }
    }
}
