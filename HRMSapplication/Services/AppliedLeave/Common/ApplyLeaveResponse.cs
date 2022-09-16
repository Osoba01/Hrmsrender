using HRMSapplication.Response.Base;

namespace HRMSapplication.Response
{
    public class ApplyLeaveResponse:BaseResponse
    {
        public string Leave { get; set; }
        public string EmployeeName { get; set; }
        public string StaffId { get; set; }
        public string Reason { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsPprove { get; set; }
        public bool IsReject { get; set; }
        public string? ApproverMessage { get; set; }
    }
}
