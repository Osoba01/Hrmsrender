using HRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Utilities
{
    public static class Logic
    {
        public static int GetAge(DateTime dob)
        {
            var currentDate = DateTime.Now;
            var age = currentDate.Year - dob.Year;
            if (currentDate > dob.AddYears(age))
                return age--;
            return age;
        }
        public static string EmployeeName(this Employee employee)
        {
            return $"{employee.FirstName} {employee.Surname} {employee.OtherName}";
        }
        public static string ListToJason(this List<string> list)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(list);
        }
        public static List<string> JsonToList(this string? str)
        {
            return (str!=null? Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(str):new List<string>())!;
        }
    }
}
