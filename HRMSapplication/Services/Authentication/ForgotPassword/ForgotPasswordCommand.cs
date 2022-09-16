using HRMS.Application.ISecurityService;
using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Common;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.ForgotPassword
{
    public record ForgotPasswordCommand(string Email):IRequest<bool>;

    public record ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, bool>, IResetPasswordEvent
    {
        private readonly IEmployeeRepo _repo;
        private readonly ITokenManager _tokenManager;

        public ForgotPasswordCommandHandler(IEmployeeRepo repo, ITokenManager tokenManager)
        {
            _repo = repo;
            _tokenManager = tokenManager;
        }

        public event EventHandler<EmployeeEventArg> ResetPassword;

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var emp = (await _repo.FindByPredicate(x => x.Email.ToLower() == request.Email.ToLower())).FirstOrDefault();
            if (emp == null || emp.VerifiedAt == null)
                return false;
            emp.ResetToken = _tokenManager.CreateRandomToken();
            emp.ResetTokenExpires = DateTime.Now.AddMinutes(10);
            _repo.PatchUpdate(emp);
            await _repo.Complete();
            OnResetPassword(emp);
             return true;


        }
        protected virtual void OnResetPassword(HRMScore.Entities.Employee employee)
        {
            ResetPassword?.Invoke(this, new EmployeeEventArg { Employee = employee });
        }

    }
    public interface IResetPasswordEvent
    {
        event EventHandler<EmployeeEventArg> ResetPassword;
    }
}
