using HRMSapplication.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.WorkExparience.CommonResponse
{
    public class ExperienceResponse:BaseResponse
    {
        public string body { get; set; }
        public string JobRole { get; set; }
        public string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string employeeName { get; set; }
    }
}
