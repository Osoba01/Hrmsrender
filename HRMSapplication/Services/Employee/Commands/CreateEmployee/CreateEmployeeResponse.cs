using HRMSapplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Commands.CreateEmployee
{
    public class CreateEmployeeResponse
    {
        public bool IsSuccess { get; set; }
        public string? FailureMessage { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? verificationToken { get; set; }
        public string? DefaultPassword { get; set; }
        public EmployeeResponse? EmployeeResponse { get; set; }
    }
}
