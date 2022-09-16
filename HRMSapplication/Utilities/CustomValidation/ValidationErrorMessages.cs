using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Utilities
{
    internal static class ValidationErrorMessages
    {
        public const string InvalidLength = "Length ({TotalLength}) of {PropertyName} Invalid.";
        public const string InvalidCharacter = "{PropertyName} Contains Invalid Character.";
        public const string InvalidDOB = "Date Of birth is out of Range.";
        public const string InvalidProperty = "{PropertyName} is Invalid.";
        public const string EmptyProperty = "{PropertyName} can not be Empty.";
        public const string InvalidMaxLength = "Length ({TotalLength}) of {PropertyName} is too long.";
        public const string InvalidStartDate = "The {PropertyName} is out of Range.";
        public const string MustBePositive = "{PropertyName} can not be less than 0.";
        public const string InvalidImage = "{Property} is not a valid image";
        public const string ImageSizeToolLarge = "{Property} size is tool large. A max of 200kb is required.";
    }
}
