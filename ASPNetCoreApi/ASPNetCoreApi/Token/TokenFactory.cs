using ASPNetCoreApi.Util;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace ASPNetCoreApi.Token
{
    public class TokenFactory
    {
        private static TokenFactory instance;

        public static TokenFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TokenFactory();
                }
                return instance;
            }
        }

        private ClaimsIdentity GetClaims(string login)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public string GetToken(string login)
        {
            DateTime now = DateTime.UtcNow;
            ClaimsIdentity claimsIdentity = GetClaims(login);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
