using FluentValidation;

namespace HRMS.Application.Services.Employee.Commands.RecoverPassword
{
    public class ResetPasswordCommandValidation:AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidation()
        {
            RuleFor(x => x.newPassword).Length(8, 50);
        }
    }
}
