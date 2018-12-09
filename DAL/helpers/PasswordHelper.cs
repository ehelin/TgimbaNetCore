using System;
using Shared.dto;
using System.Security.Cryptography;
using DAL.misc;

namespace DAL.helpers
{
    public class PasswordHelper
    {
        public NewPassword GetPassword(string clearTxtPassword)
        {
            NewPassword np = new NewPassword(clearTxtPassword);

            np.Salt = GetSalt();
            np = HashPassword(np);

            return np;
        }
        public bool UserExists(User u, string suppliedPassword)
        {
            bool goodUser = ComparePasswords(u, suppliedPassword);

            return goodUser;
        }
        private bool ComparePasswords(User u, string suppliedPass)
        {
            bool goodUser = false;
            NewPassword np = new NewPassword(suppliedPass);

            np.Salt = u.Salt;
            np = HashPassword(np);

            if (u.Password.Equals(np.SaltedHashedPassword))
                goodUser = true;

            return goodUser;
        }
        private string GetSalt()
        {
            RNGCryptoServiceProvider saltGen = null;
            string salt = string.Empty;

            try
            {
                saltGen = new RNGCryptoServiceProvider();
                byte[] buffer = new byte[Constants.SALT_SIZE];
                saltGen.GetBytes(buffer);
                salt = Convert.ToBase64String(buffer);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (saltGen != null)
                {
                    saltGen.Dispose();
                    saltGen = null;
                }
            }

            return salt;
        }
        private NewPassword HashPassword(NewPassword np)
        {
            HashAlgorithm hashAlg = null;

            try
            {
                hashAlg = new SHA256CryptoServiceProvider();
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(np.GetSaltPassword());
                byte[] bytHash = hashAlg.ComputeHash(bytValue);
                np.SaltedHashedPassword = Convert.ToBase64String(bytHash);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (hashAlg != null)
                {
                    hashAlg.Clear();
                    hashAlg.Dispose();
                    hashAlg = null;
                }
            }

            return np;
        }
    }
}
