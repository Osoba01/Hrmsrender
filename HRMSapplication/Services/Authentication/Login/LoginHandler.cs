using AutoMapper;
using HRMS.Application.Services.EmployeeService.Common;
using HRMS.Auth;
using HRMS.Domain.IRepositories;
using HRMSapplication.Login;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.Login
{
    public record LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IAuthService _authService;
        public LoginHandler(IEmployeeRepo repo, IAuthService authService)
        {

            _repo = repo;
            _authService = authService;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginResponse logResp = new();
            var emp=(await _repo.FindByPredicate(x => x.Email==request.Email.ToLower())).FirstOrDefault();
            if (emp!=null)
            {

                if (emp.VerifiedAt != null)
                {
                    var isAuth = _authService.VerifyPassword(request.Password, emp);
                    if (isAuth)
                    {
                        logResp.IsAuthenticated = true;
                        logResp.Isverify = true;
                        logResp.TokenModel= await _authService.GetToken(emp);
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
