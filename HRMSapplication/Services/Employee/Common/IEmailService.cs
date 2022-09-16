using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Common
{
    public interface IEmailService
    {
       void OnCreateEmployee(object? source, EmployeeEventArg e);

        void OnResetPassword(object? source, EmployeeEventArg e);
    }
}
