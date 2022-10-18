
using HRMS.Application.AuthenticateRefreshToken;
using MediatR;
using HRMS.Auth;
using HRMS.Domain.IRepositories;

namespace HRMS.Application.Queries.AuthenticateRefreshToken
{
    public record AuthenticateRefreshTokenQueryHandler : IRequestHandler<AuthenticateRefreshTokenQuery, TokenModel>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IAuthService _authService;

        public AuthenticateRefreshTokenQueryHandler(IEmployeeRepo repo, IAuthService authService)
        {
            _repo = repo;
            _authService = authService;

        }
        public async Task<TokenModel> Handle(AuthenticateRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var p = (await _repo.FindByPredicate(x => x.RefreshToken == request.RefreshToken)).FirstOrDefault() ;
           
            TokenModel aut = new();
            
            if (p != null)
            {
               await _authService.GetToken(p);
            }
            return aut;
        }
    }
}
