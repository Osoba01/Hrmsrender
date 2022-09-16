using HRMSapplication.Response.Base;
using HRMScore.HRMSenums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.EmployeeProject.Query
{
    public class EmployeeProjectResponse:BaseResponse
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Link { get; set; }
        public ProjectState Status { get; set; }

    }
}
