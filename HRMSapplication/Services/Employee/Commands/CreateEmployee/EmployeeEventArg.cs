using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.CreateEmployee
{
    public class EmployeeEventArg:EventArgs
    {
        public Domain.Entities.Employee? Employee { get; set; }
    }
}
