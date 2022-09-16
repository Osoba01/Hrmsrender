using HRMScore.Entities.Base;

namespace HRMScore.Entities
{
    public class ApplyLeave: BaseEntity
    {
        public Leave Leave { get; set; }
        public Employee Employee { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsPprove { get; set; }
        public bool IsReject { get; set; }
        public string? ApproverMessage { get; set; }
    }
}
