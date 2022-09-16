using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.ApplyForLeave
{
    public class ApplyLeaveValidation:AbstractValidator<ApplyForLeaveCommand>
    {
        public ApplyLeaveValidation()
        {
            RuleFor(a => a.LeaveId)
                .Must(BeAValidGuid).WithMessage(InvalidProperty);
            RuleFor(a=>a.EmployeeId)
                .Must(BeAValidGuid).WithMessage(InvalidProperty);
            RuleFor(a => a.Reason)
                .MaximumLength(200).WithMessage(InvalidMaxLength);
            RuleFor(a => a.StartDate)
                .Must(BeAValidStartDate).WithMessage(InvalidStartDate);
        }
    }
}
