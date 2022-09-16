using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Test
{
    public static class DommmyData
    {
        

        public static HRMScore.Entities.Department dept1 = new HRMScore.Entities.Department() { Id = Guid.NewGuid(), HOD = employee1, Name = "Apply Mathematics", Description = "We do the shit" };
        public static HRMScore.Entities.Department dept2 = new HRMScore.Entities.Department() { Id = Guid.NewGuid(), HOD = employee2, Name = "Softwere", Description = "Develop all kind of software" };
        public static HRMScore.Entities.Department dept3 = new HRMScore.Entities.Department() { Id = Guid.NewGuid(), HOD = employee3, Name = "HR", Description = "Human resource activities" };

        public static HRMScore.Entities.Employee employee1 = new() { Id = Guid.NewGuid(), FirstName = "Samuel", Surname = "Jaja", Department = dept1 };
        public static HRMScore.Entities.Employee employee2 = new() { Id = Guid.NewGuid(), FirstName = "Kelly", Surname = "Osoba", OtherName = "Eromosele", Manager = employee2, Department = dept2 };
        public static HRMScore.Entities.Employee employee3 = new() { Id = Guid.NewGuid(), FirstName = "Peace", Surname = "Sunday", OtherName = "Faith", Manager = employee2, Department = dept2 };
        public static HRMScore.Entities.Employee employee4 = new() { Id = Guid.NewGuid(), FirstName = "Peter", Surname = "Monday", OtherName = "Eze", Manager = employee2, Department = dept2 };
        public static HRMScore.Entities.Employee employee5 = new() { Id = Guid.NewGuid(), FirstName = "Kennedy", Surname = "Emmanuel", OtherName = "Chima", Manager = employee1, Department = dept1 };
        public static List<string> StringList = new(new[] { "C#", "Vue Js", "React Js", "Wab Api" });
        public static List<HRMScore.Entities.Department> Departments()
        {
            var depts = new List<HRMScore.Entities.Department>();
            depts.Add(dept1);
            depts.Add(dept2);
            depts.Add(dept3);
            return depts;
        }
        public static List<HRMScore.Entities.Employee> Employees()
        {
            var emp= new List<HRMScore.Entities.Employee>();
            emp.Add(employee1);
            emp.Add(employee2);
            emp.Add(employee3);
            emp.Add(employee4);
            emp.Add(employee5);
            return emp;
        }
    }
}
