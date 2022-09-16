using HRMS.Application.ISecurityService;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.RecoverPassword
{
    public record ResetPasswordCommand(string PasswordRecoverToken, string email, string newPassword):IRequest<bool>;
    public record RecoverPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IEncryption _encryption;

        public RecoverPasswordCommandHandler(IEmployeeRepo repo, IEncryption encryption)
        {
            _repo = repo;
            _encryption = encryption;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var emp=(await _repo.FindByPredicate(x=>
            x.ResetToken==request.PasswordRecoverToken &&
            x.Email.ToLower()==request.email.ToLower())).FirstOrDefault();
            if (emp==null || emp.ResetTokenExpires<DateTime.UtcNow)
                return false;
            _repo.PatchUpdate(emp);
            _encryption.EncryptPasswordAsync(emp, request.newPassword);
            await _repo.Complete();
            return true;
        }
    }
}
