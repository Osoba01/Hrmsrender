using HRMSapplication.Response.Base;

namespace HRMSapplication.Response
{
    public class PerformanceResponse:BaseResponse
    {
        public string EmployeeName { get; set; }
        public string StaffId { get; set; }
        public double MonthlyRating { get; set; }
        public DateTime Month { get; set; }
    }
}
