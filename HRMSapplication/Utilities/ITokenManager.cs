using HRMScore.Entities;

namespace HRMS.Application.ISecurityService
{
    public interface ITokenManager
    {
        string CreateRandomToken();
        string CreateAccessToken(Employee employee);
    }
}
