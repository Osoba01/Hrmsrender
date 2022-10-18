
using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Common;
using HRMS.Auth;
using HRMS.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.ForgotPassword
{
    public record ForgotPasswordCommand(string Email):IRequest<bool>;

    public record ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool>, IResetPasswordEvent
    {
        private readonly IEmployeeRepo _repo;
        private readonly IAuthService _authService;

        public ForgotPasswordCommandHandler(IEmployeeRepo repo, IAuthService authService)
        {
            _repo = repo;
            _authService = authService;
        }

        public event EventHandler<EmployeeEventArg> ResetPassword;

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var emp = (await _repo.FindByPredicate(x => x.Email.ToLower() == request.Email.ToLower())).FirstOrDefault();
            if (emp == null || emp.VerifiedAt == null)
                return false;
            emp.ResetToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            emp.ResetTokenExpires = DateTime.Now.AddMinutes(10);
            _repo.PatchUpdate(emp);
            await _repo.Complete();
            OnResetPassword(emp);
             return true;


        }
        protected virtual void OnResetPassword(Domain.Entities.Employee employee)
        {
            ResetPassword?.Invoke(this, new EmployeeEventArg { Employee = employee });
        }

    }
    public interface IResetPasswordEvent
    {
        event EventHandler<EmployeeEventArg> ResetPassword;
    }
}
