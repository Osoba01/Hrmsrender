using HRMScore.Entities.Base;

namespace HRMScore.Entities
{
    public class Performance: BaseEntity
    {
        public Performance()
        {
            Month = DateTime.Today;
        }
        public Employee Employee { get; set; }
        public double   MonthlyRating { get; set; }
        public DateTime Month { get; set; }
    }
}
