using HRMSapplication.Response.Base;

namespace HRMSapplication.Response
{
    public class LeaveResponse:BaseResponse
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public decimal Allowance { get; set; }
    }
}
