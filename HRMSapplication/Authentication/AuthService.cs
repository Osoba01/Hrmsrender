
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace HRMS.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly IEmployeeRepo _employeeRepo;

        public AuthService( IConfiguration config, IEmployeeRepo employee)
        {
            _config = config;
            _employeeRepo = employee;
        }
        public async Task<TokenModel> GetToken(Employee employee)
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
                Expires = DateTime.UtcNow.AddMinutes(1440)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string refreshToken = $"{GenerateRefreshToken()}{employee.Id}";
            _employeeRepo.PatchUpdate(employee);
            employee.RefreshToken = refreshToken;
            employee.ResetTokenExpires = DateTime.UtcNow.AddDays(1);
            await _employeeRepo.Complete();

            return new TokenModel
            {
                AccessToken = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken,
            };
        }
        static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }

        public void EncryptPassword(string password, Employee employee)
        {
            using (var hmc = new HMACSHA512())
            {
                byte[] passwordSalt = hmc.Key;
                byte[] passwordHash = hmc.ComputeHash(Encoding.ASCII.GetBytes(password));
                employee.PasswordHash = passwordHash;
                employee.PasswordSalt = passwordSalt;
            }
        }

        public bool VerifyPassword(string password, Employee employee)
        {
            using (var hmc = new HMACSHA512(employee.PasswordSalt))
            {
                byte[] computed = hmc.ComputeHash(Encoding.ASCII.GetBytes(password));
                return computed.SequenceEqual(employee.PasswordHash);
            }
        }

        public string GetRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new();
            Random rnd = new();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
