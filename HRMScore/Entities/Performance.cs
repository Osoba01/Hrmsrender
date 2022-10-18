using HRMS.Domain.Entities.Base;

namespace HRMS.Domain.Entities
{
    public class Performance : BaseEntity
    {
        public Performance()
        {
            Month = DateTime.Today;
        }
        public Employee Employee { get; set; }
        public double MonthlyRating { get; set; }
        public DateTime Month { get; set; }
    }
}
