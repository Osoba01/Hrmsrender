using HRMS.Domain.Entities.Base;
using HRMScore.HRMSenums;

namespace HRMS.Domain.Entities
{
    public class EmployeeProject : BaseEntity
    {
        public EmployeeProject()
        {
            Employee = new();
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public ProjectState Status {get;set;}
        public Employee Employee { get; set; }
    }
}
