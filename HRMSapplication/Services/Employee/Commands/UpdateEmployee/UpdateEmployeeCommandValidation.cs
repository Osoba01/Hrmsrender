using FluentValidation;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMSapplication.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidation:AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidation()
        {
            RuleFor(e => e.Id)
                .Must(BeAValidGuid).WithMessage(InvalidProperty);
            RuleFor(e => e.FirstName)
               .NotEmpty().WithMessage(EmptyProperty)
               .Length(2, 50).WithMessage(InvalidLength)
               .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(e => e.Surname)
               .NotEmpty().WithMessage(EmptyProperty)
               .Length(2, 50).WithMessage(InvalidLength)
               .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(e => e.OtherName)
               .MaximumLength(50).WithMessage(InvalidLength)
               .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(e => e.ContactAddress)
                .NotEmpty().WithMessage(EmptyProperty);
            RuleFor(e => e.PhoneNo)
                .Length(10, 25).WithMessage(InvalidLength);
            RuleFor(e => e.Gender)
                .IsInEnum().WithMessage(InvalidProperty);
            RuleFor(e => e.StateOfOrigin)
                .Length(1, 30).WithMessage(InvalidLength);
            RuleFor(e => e.DOB)
                .Must(BeAValidDOB).WithMessage(InvalidDOB);

            RuleFor(e => e.NextOfKingFirstName)
                 .NotEmpty().WithMessage(EmptyProperty)
                .Length(2, 150).WithMessage(InvalidLength)
                .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(e => e.NextOfKingSurName)
                 .NotEmpty().WithMessage(EmptyProperty)
                .Length(2, 150).WithMessage(InvalidLength)
                .Must(BeAValidName).WithMessage(InvalidCharacter);
            RuleFor(e => e.NextOfKingPhoneNo)
                .Length(10, 25).WithMessage(InvalidLength);
            RuleFor(e => e.NextOfKingEmail)
               .EmailAddress().WithMessage(InvalidProperty);
            RuleFor(e => e.NextOfKingAddress)
               .NotEmpty().WithMessage(EmptyProperty);
            RuleFor(e=>e.Relationship)
                .IsInEnum();

            RuleFor(e => e.DepartmentId)
                .NotNull().WithMessage(InvalidProperty);
            RuleFor(e=>e.ContractType)
                .IsInEnum().WithMessage(InvalidProperty);
            RuleFor(e => e.WorkType)
                .IsInEnum().WithMessage(InvalidProperty);



        }
    }
}
