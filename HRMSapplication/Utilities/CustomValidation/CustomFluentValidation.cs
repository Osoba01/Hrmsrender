using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Utilities
{
    internal static class CustomFluentValidation
    {
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPEG", ".JPE", ".BMP", ".GIF", ".PNG" };
        public static bool BeAValidDOB(DateTime dob)
        {
            int currentyear = DateTime.Now.Year;
            int dobyear = dob.Year;
            if (dobyear < currentyear && (currentyear - dobyear) < 120)
                return true;
            return false;
        }
        public static bool BeAValidStartDate(DateTime dob)
        {
            int currentyear = DateTime.Now.Year;
            int startyear = dob.Year;
            if (startyear < currentyear && (currentyear - startyear) < 100)
                return true;
            return false;
        }
        public static bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("_", "");
            return name.All(char.IsLetter);
        }
        public static bool BeAValidGuid(Guid id)
        {
            return id.ToString().Length == 36;
        }
        public static bool BeAnImage(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return ImageExtensions.Contains(extension.ToUpper());
        }
        public static bool BeAValidImageSize(IFormFile file)
        {
            return file.Length < 200000;
        }
    }
}
