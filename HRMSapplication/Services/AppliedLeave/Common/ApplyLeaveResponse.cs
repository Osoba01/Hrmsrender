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
        
        public DateTime EndDate { get; set; }
        public bool IsPprove { get; set; }
        public bool IsReject { get; set; }
        public string? ApproverMessage { get; set; }

        public int DaysRemain
        {
            get {
                if (StartDate.Date<DateTime.Now.Date)
                {
                    var currentDate = DateTime.Now;
                    int daysRemain= EndDate.Day-currentDate.Day;
                    if (daysRemain<0)
                        return 0;
                    return daysRemain;
                }
                return EndDate.Day-StartDate.Day; 
            }

        }


    }
}
