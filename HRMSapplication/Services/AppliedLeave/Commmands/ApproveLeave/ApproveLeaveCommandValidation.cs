using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.ApproveLeave
{
    public class ApproveLeaveCommandValidation:AbstractValidator<ApproveLeaveCommand>
    {
        public ApproveLeaveCommandValidation()
        {
            RuleFor(a => a.ApplyLeaveId)
               .Must(BeAValidGuid).WithMessage(InvalidProperty);
            RuleFor(a => a.message)
                .MaximumLength(200).WithMessage(InvalidMaxLength);
        }
    }
}
