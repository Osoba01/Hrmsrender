using HRMSapplication.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Response
{
    public class DepartmentResponse: BaseResponse
    {
        public string Name { get; set; }
        public string? HOD { get; set; }
        public string? Description { get; set; }
        public int CountEmployee { get; set; }
    }
}
