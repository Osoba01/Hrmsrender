using FluentValidation;
using HRMScore.HRMSenums;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.UpdateEmployeeDepartment
{
    public class UpdateEmployeeRoleCommandValidation : AbstractValidator<UpdateEmployeeRoleCommand>
    {
        public UpdateEmployeeRoleCommandValidation()
        {
            RuleFor(e => e.EmployeeId)
                .Must(BeAValidGuid).WithMessage(InvalidProperty);
            RuleFor(e=>e.Role)
                .IsInEnum().WithMessage(InvalidProperty);
        }
    }
}
