using HRMS.Domain.Entities.Base;
using HRMScore.HRMSenums;

namespace HRMS.Domain.Entities
{
    public class Skill:BaseEntity
    {
        public string SkillName { get; set; }
        public SkillType SkillType { get; set; }
        public int Proficiency { get; set; }
        public Employee Employee { get; set; }
    }
}
