
using HRMS.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Auth
{
    public class AuthService
    {
        public HttpContextAccessor _httpContext { get; }
        private readonly IConfiguration _config;

        public AuthService(HttpContextAccessor httpContext,IConfiguration config)
        {
            _httpContext = httpContext;
            _config = config;
        }
        public TokenModel GetToken(Employee employee)
        {
            var key = Encoding.ASCII.GetBytes(_config["AppSetting:Token"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                        new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier,employee.Id.ToString()),
                            new Claim(ClaimTypes.Email,employee.Email),
                            new Claim(ClaimTypes.Role,employee.Role.ToString())
                        }
                    ),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow.AddMinutes(5)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
           
            return new TokenModel
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = GenerateRefreshToken(),
                RefreshTokenExpire=DateTime.UtcNow
            };
        }
        static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)); 
        }
    }
}
