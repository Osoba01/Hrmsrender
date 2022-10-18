using HRMS.Domain.Entities.Base;

namespace HRMS.Domain.Entities
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        public string Name { get; set; }
        public Employee? HOD { get; set; }
        public string? Description { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

    }
}
