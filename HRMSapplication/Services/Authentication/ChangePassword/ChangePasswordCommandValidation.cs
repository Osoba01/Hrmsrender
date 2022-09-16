using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.ChangePassword
{
    public class ChangePasswordCommandValidation:AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidation()
        {
            RuleFor(x => x.EmployeeId)
               .Must(BeAValidGuid).WithMessage(InvalidProperty);
            RuleFor(x=>x.OldPassword)
                .Length(8,50).WithMessage(InvalidLength);
            RuleFor(x=>x.NewPassword)
                .Length(8, 50).WithMessage(InvalidLength);
        }
    }
}
