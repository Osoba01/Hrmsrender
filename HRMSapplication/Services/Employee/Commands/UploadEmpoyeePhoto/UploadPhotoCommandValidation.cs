using FluentValidation;
using HRMSapplication.Commands.UploadEmpoyeePhoto;
using static HRMS.Application.Utilities.CustomFluentValidation;
using static HRMS.Application.Utilities.ValidationErrorMessages;

namespace HRMS.Application.Services.Employee.Commands.UploadEmpoyeePhoto
{
    public class UploadPhotoCommandValidation:AbstractValidator<UploadEmployeePhotoCommand>
    {
        public UploadPhotoCommandValidation()
        {
            RuleFor(x => x.EmployeeId)
                .Empty();
            RuleFor(x => x.Photo)
                .NotNull()
                .NotEmpty()
                .Must(BeAnImage).WithMessage(InvalidImage)
                .Must(BeAValidImageSize).WithMessage(ImageSizeToolLarge);
        }
    }
}
