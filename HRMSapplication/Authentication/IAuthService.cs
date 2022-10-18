using HRMS.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HRMS.Auth
{
    public interface IAuthService
    {

        void EncryptPassword(string password, Employee employee);
        Task<TokenModel> GetToken(Employee employee);
        bool VerifyPassword(string password, Employee employee);
        string GetRandomPassword(int length);
    }
}