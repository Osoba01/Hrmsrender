using HRMS.Application.ISecurityService;
using HRMS.Application.AuthenticateRefreshToken;
using MediatR;
using HRMScore.IRepositories;

namespace HRMS.Application.Queries.AuthenticateRefreshToken
{
    public record AuthenticateRefreshTokenQueryHandler : IRequestHandler<AuthenticateRefreshTokenQuery, AuthenticateRefreshTokenResponse>
    {
        private readonly IEmployeeRepo _repo;
        private readonly ITokenManager _tokenManager;

        public AuthenticateRefreshTokenQueryHandler(IEmployeeRepo repo, ITokenManager tokenManager)
        {
            _repo = repo;
            _tokenManager = tokenManager;
        }
        public async Task<AuthenticateRefreshTokenResponse> Handle(AuthenticateRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var p=(await _repo.GetAll()).FirstOrDefault(x=>x.RefreshToken==request.RefreshToken) ;
            AuthenticateRefreshTokenResponse aut = new();
            if (p != null)
            {
                aut.IsAuthenticate=true;
                aut.AccessToken=_tokenManager.CreateAccessToken(p);
            }
            return aut;
        }
    }
}
