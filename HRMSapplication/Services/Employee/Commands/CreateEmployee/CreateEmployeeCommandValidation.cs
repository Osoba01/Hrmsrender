using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidation : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidation()
        {
            RuleFor(e => e.Email)
                .EmailAddress().WithMessage(InvalidProperty);
            RuleFor(e => e.Role)
                  .IsInEnum().WithMessage(InvalidProperty);
        }
    }
}
