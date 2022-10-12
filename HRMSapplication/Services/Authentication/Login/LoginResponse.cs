using HRMS.Auth;
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
            TokenModel = new();
        }
        public bool IsAuthenticated { get; set; }
        public bool Isverify { get; set; }
        public TokenModel TokenModel { get; set; }
        public string FailMessage { get; set; }
    }
}
