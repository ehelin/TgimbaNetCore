using System.Security.Cryptography;
using Shared;
using Shared.interfaces;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;

namespace BLLNetCore.Security
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

        public string GetJwtToken(string jwtPrivateKey, string jwtIssuer)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtPrivateKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            var token = new JwtSecurityToken(jwtIssuer,
              jwtIssuer,
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtSecurityTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
