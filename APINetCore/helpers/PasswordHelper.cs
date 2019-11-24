using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Shared;
using Shared.dto;
using Shared.interfaces;

namespace BLLNetCore.Security // TODO - change namespace to BLLNetCore.helpers
{
    public class PasswordHelper : IPassword
    {
        private IGenerator generator = null;

        public PasswordHelper()
        {
            generator = new GeneratorHelper();
        }
               
        public bool IsValidUserToRegister(string user, string email, string password)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(user) || user.Equals("null"))
                valid = false;
            else if (string.IsNullOrEmpty(email) || email.Equals("null"))
                valid = false;
            else if (string.IsNullOrEmpty(password) || password.Equals("null"))
                valid = false;
            else if (user.Length < Shared.Constants.REGISTRATION_VALUE_LENGTH)
                valid = false;
            else if (password.Length < Shared.Constants.REGISTRATION_VALUE_LENGTH)
                valid = false;
            else if (!this.ContainsOneNumber(password))
                valid = false;
            else if (email.IndexOf(Shared.Constants.EMAIL_AT_SIGN) < 1)
                valid = false;

            return valid;
        }

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

        public bool IsValidToken(User user, string token)
        {
            bool isValid = false;

            if (user != null
                    && !string.IsNullOrEmpty(user.Token)
                        && !string.IsNullOrEmpty(token)
                            && user.Token.Equals(token))
            {
                var jwtToken = this.generator.DecryptJwtToken(token);

                DateTime now = DateTime.UtcNow;
                if (jwtToken.ValidTo >= now)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
