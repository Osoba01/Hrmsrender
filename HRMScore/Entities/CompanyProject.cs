using HRMS.Domain.Entities.Base;
using HRMScore.HRMSenums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities
{
    public class CompanyProject: BaseEntity
    {
        public CompanyProject()
        {
            Team = new();
        }
        public string Name { get; set; }
      
        public List<Employee> Team { get; set; }
        public Employee Manager { get; set; }
        public ProjectState ProjectStatus { get; set; }
    }
}
