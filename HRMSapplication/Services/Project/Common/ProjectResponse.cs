using HRMSapplication.Response.Base;
using HRMScore.HRMSenums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Project.CommonResponse
{
    public class ProjectResponse:BaseResponse
    {
        public string Name { get; set; }
        public ProjectState ProjectStatus { get; set; }
    }
}
