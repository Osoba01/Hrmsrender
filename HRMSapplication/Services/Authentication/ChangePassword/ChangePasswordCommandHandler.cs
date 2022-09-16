using HRMS.Application.ISecurityService;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.ChangePassword
{
    public record ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand,bool>
    {
        private readonly IEmployeeRepo repo;
        private readonly IEncryption encryption;

        public ChangePasswordCommandHandler(IEmployeeRepo repo, IEncryption encryption)
        {
            this.repo = repo;
            this.encryption = encryption;
        }
        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var emp = (await repo.GetAll()).FirstOrDefault(x => x.Id == request.EmployeeId);
            if (emp != null)
            {
                var IsAuth = encryption.VerifyPasswordAsync(request.OldPassword, emp.PasswordHash, emp.PasswordSalt);
                if (IsAuth)
                {
                    repo.PatchUpdate(emp);
                    encryption.EncryptPasswordAsync(emp, request.NewPassword);
                    await repo.Complete();
                    return true;
                }
                else
                    return false;
            }
            else
                throw new ArgumentException("User not found.");
            
        }
    }
}
