using JwtAuthentcationManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentcationManager
{
    public class JwtTokenHandler
    {
        public const int JWT_TOKEN_VALIDITY_MINS = 20;
        public const string JWT_SECURITY_KEY = "asdjiojwoidhuidgnflksdjio13jik@adu1*(asd2";
        List<UserAccount> userAccounts;
        public JwtTokenHandler()
        { 
            userAccounts = new List<UserAccount>()
            {
                new UserAccount { UserName = "admin", Password = "admin123", Role = "Admin" },
                new UserAccount { UserName = "user", Password = "user123", Role = "User" }
            };
        }

        public AuthenticationResponse GetToken(string username, string role) {


            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim> {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role),
            });

            var signingCredential = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);
            
            var securityToeDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredential
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityToeDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                Username = username,
                Token = token,
                EpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }


    }
}
