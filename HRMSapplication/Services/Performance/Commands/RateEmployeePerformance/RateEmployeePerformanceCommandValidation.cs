using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.RateEmployeePerformance
{
    public class RateEmployeePerformanceCommandValidation:AbstractValidator<RateEmployeePerformanceCommand>
    {
        public RateEmployeePerformanceCommandValidation()
        {
            RuleFor(x => x.EmployeeId)
                .Must(BeAValidGuid).WithMessage(EmptyProperty);
            RuleFor(x => x.MonthlyRating)
                .GreaterThanOrEqualTo(0).WithMessage(MustBePositive)
                .LessThanOrEqualTo(10);
            RuleFor(x => x.Month)
                 .Must(BeAValidStartDate).WithMessage(InvalidStartDate);
        }
    }
}
