using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.CreateLeave
{
    public class CreateLeaveCommandValidation:AbstractValidator<CreateLeaveCommand>
    {
        public CreateLeaveCommandValidation()
        {
            RuleFor(x=>x.Name)
                 .NotEmpty().WithMessage(EmptyProperty)
                .Length(2, 150).WithMessage(InvalidLength)
                .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(x => x.Days)
                 .GreaterThanOrEqualTo(0).WithMessage(MustBePositive);
            RuleFor(x => x.Allowance)
                .GreaterThanOrEqualTo(0).WithMessage(MustBePositive);
        }
    }
}
