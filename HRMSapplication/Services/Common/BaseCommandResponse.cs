using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Common
{
    public class BaseCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = "";
    }
}
