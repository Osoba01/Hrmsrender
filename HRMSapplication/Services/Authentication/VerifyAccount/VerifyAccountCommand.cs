using HRMS.Auth;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMS.Application.Services.Security.VerifyAccount
{
    public record VerifyAccountCommand(string verifyToken, string Password, string email):IRequest<bool>;

    public record VerifyAccountCommandHandle : IRequestHandler<VerifyAccountCommand, bool>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IAuthService _authService;

        public VerifyAccountCommandHandle(IEmployeeRepo repo, IAuthService authService)
        {
            _repo = repo;
            _authService = authService;
        }
        public async Task<bool> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
        {
            var emp = (await _repo.FindByPredicate(x =>
              x.VerificationToken == request.verifyToken)).FirstOrDefault();
              //x.Email.ToLower() == request.email.ToLower()));
            if (emp == null || emp.ResetTokenExpires < DateTime.UtcNow)
                return false;
            _repo.PatchUpdate(emp);
            _authService.EncryptPassword(request.Password,emp);
            emp.VerifiedAt = DateTime.UtcNow;
            return await _repo.Complete()>0;
            
        }
    }
}
