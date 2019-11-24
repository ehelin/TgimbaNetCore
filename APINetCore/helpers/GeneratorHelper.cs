using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Shared;
using Shared.interfaces;

namespace BLLNetCore.Security // TODO - change namespace to BLLNetCore.helpers
{
    public class GeneratorHelper : IGenerator
    {
        public string GetJwtPrivateKey() 
        {
            // TODO - re test this after .net core 3 is installed
            //RSA rsa = new RSACryptoServiceProvider(2048); // Generate a new 2048 bit RSA key
            //string key = rsa.ToXmlString(true);

            //NOTE: Temporary key generated from NetClassicUtility...replace when .net core has 
            //      same functionality as .Net Classic
            string key = Credentials.GetJwtPrivateKey();

            return key;
        }

        public string GetJwtIssuer() 
        {
            var issuer = Credentials.GetJwtIssuer();

            return issuer;
        }

        public SecurityToken DecryptJwtToken(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.ReadToken(token);

            return jwtToken;
        }

        // TODO - add test for variable token life
        public string GetJwtToken(string jwtPrivateKey, string jwtIssuer, int tokenLife = Constants.TOKEN_LIFE)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtPrivateKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiresIn = DateTime.UtcNow.AddMinutes(tokenLife);
            
            var claims = new List<Claim>();
            var token = new JwtSecurityToken(jwtIssuer,
              jwtIssuer,
              claims,
              expires: expiresIn,
              signingCredentials: credentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
