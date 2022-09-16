using HRMScore.Entities;
using HRMScore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Entities
{
    public class WorkExperience: BaseEntity
    {
        public string Body { get; set; }
        public string JobRole { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Employee Employee { get; set; }
        public string TestingMigration { get; set; }
    }
}
