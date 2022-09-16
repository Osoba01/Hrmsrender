using AutoMapper;
using HRMS.Application.ISecurityService;
using HRMS.Application.Services.EmployeeService.Common;
using HRMSapplication.Login;
using HRMSapplication.Response;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Queries.Login
{
    public record LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapEmployee _map;
        private readonly ITokenManager _token;
        private readonly IEncryption ecrypt;

        public LoginHandler(IEmployeeRepo repo, IMapEmployee map,ITokenManager token, IEncryption ecrypt)
        {

            _repo = repo;
            _map = map;
            _token = token;
            this.ecrypt = ecrypt;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginResponse logResp = new();
            var emp=(await _repo.FindByPredicate(x => x.Email.ToLower()==request.Email.ToLower())).FirstOrDefault();
            if (emp!=null)
            {

                if (emp.VerifiedAt != null)
                {
                    var isAuth = ecrypt.VerifyPasswordAsync(request.Password, emp.PasswordHash, emp.PasswordSalt);
                    if (isAuth)
                    {
                        logResp.IsAuthenticated = true;
                        logResp.Isverify = true;
                        logResp.AccessToken = _token.CreateAccessToken(emp);
                        logResp.NewRefreshToken = _token.CreateRandomToken();
                        logResp.EmployeeResponse = _map.EntityToResponse(emp);
                        _repo.PatchUpdate(emp);
                        emp.RefreshToken = logResp.NewRefreshToken;
                        await _repo.Complete();
                    }
                    else
                        logResp.FailMessage = "Email or Password is Invalid.";
                }
                else
                    logResp.FailMessage = "Account is not verify yet.";
            }
            else
                logResp.FailMessage = "Email or Password is Invalid.";
            return logResp;
        }
    }
}
