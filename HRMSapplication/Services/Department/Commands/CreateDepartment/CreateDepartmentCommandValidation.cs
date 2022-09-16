using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidation:AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidation()
        {
            RuleFor(X=>X.Name)
                .NotEmpty().WithMessage(EmptyProperty)
                .Length(2, 150).WithMessage(InvalidLength)
                .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(X=>X.Description)
                .MaximumLength(200).WithMessage(InvalidMaxLength);
        }
    }
}
