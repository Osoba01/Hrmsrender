using HRMSapplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Login
{
    public class LoginResponse
    {
        public LoginResponse()
        {
           
            EmployeeResponse = new EmployeeResponse();
        }
        public bool IsAuthenticated { get; set; }
        public bool Isverify { get; set; }
        public string? AccessToken { get; set; }
        public string? NewRefreshToken { get; set; }
        public EmployeeResponse EmployeeResponse { get; set; }
        public string FailMessage { get; set; }
    }
}
