using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CEP.Helpers.Tokens
{
    public class TokenHelper
    {
        public static string CreateToken(string signInKey, string issuer, string audience, string email)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signInKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer,
              audience,
              expires: DateTime.Now.AddHours(1),
              signingCredentials: creds,
              claims: new List<Claim>()
              {
                  new Claim(ClaimTypes.Email, email)
              });

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
