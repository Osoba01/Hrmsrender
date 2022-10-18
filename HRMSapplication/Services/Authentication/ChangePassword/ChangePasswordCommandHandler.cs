
using HRMS.Auth;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.ChangePassword
{
    public record ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand,bool>
    {
        private readonly IEmployeeRepo repo;
        private readonly IAuthService _authService;


        public ChangePasswordCommandHandler(IEmployeeRepo repo, IAuthService authService)
        {
            this.repo = repo;
            _authService = authService;

        }
        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var emp = (await repo.GetAll()).FirstOrDefault(x => x.Id == request.EmployeeId);
            if (emp != null)
            {
                var IsAuth = _authService.VerifyPassword(request.OldPassword, emp);
                if (IsAuth)
                {
                    repo.PatchUpdate(emp);
                    _authService.EncryptPassword(request.NewPassword, emp);
                    await repo.Complete();
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
        }
    }
}
