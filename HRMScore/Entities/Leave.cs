using HRMS.Domain.Entities.Base;

namespace HRMS.Domain.Entities
{
    public class Leave : BaseEntity
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public decimal Allowance { get; set; }
        public List<ApplyLeave> applyLeaves { get; set; }
    }
}
