
using HRMS.Auth;
using HRMS.Domain.IRepositories;
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
        private readonly IAuthService _authService;

        public RecoverPasswordCommandHandler(IEmployeeRepo repo, IAuthService authService)
        {
            _repo = repo;
            _authService = authService;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var emp=(await _repo.FindByPredicate(x=>
            x.ResetToken==request.PasswordRecoverToken &&
            x.Email.ToLower()==request.email.ToLower())).FirstOrDefault();
            if (emp==null || emp.ResetTokenExpires<DateTime.UtcNow)
                return false;
            _repo.PatchUpdate(emp);
            _authService.EncryptPassword(request.newPassword,emp);
            await _repo.Complete();
            return true;
        }
    }
}
