using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Query.GetSkill
{
    public class SkillResponse
    {
        public SkillResponse()
        {
            SoftSkill = new List<string>();
            Technical = new List<string>();
        }
        public List<string> SoftSkill { get; set; }
        public List<string> Technical { get; set; }
    }
}
