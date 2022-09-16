using HRMS.Application.ISecurityService;
using HRMScore.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HRMS.Infrastructure.SecurityServices
{
    public class TokenManager : ITokenManager
    {
        private readonly string _key;

        public TokenManager(string key)
        {
            _key=key;
        }
        public string CreateRandomToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
        public string CreateAccessToken(Employee employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,employee.Id.ToString()),
                new Claim(ClaimTypes.Email,employee.Email),
                new Claim(ClaimTypes.Role,employee.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credential,
                expires: DateTime.Now.AddMinutes(20)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
