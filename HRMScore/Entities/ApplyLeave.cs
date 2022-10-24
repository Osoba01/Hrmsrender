using HRMS.Domain.Entities.Base;

namespace HRMS.Domain.Entities
{
    public class ApplyLeave : BaseEntity
    {
        public ApplyLeave()
        {
            Reason = "";
        }
        public Leave Leave { get; set; }
        public Employee Employee { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsPprove { get; set; }
        public bool IsReject { get; set; }
        public string? ApproverMessage { get; set; }
    }
}
