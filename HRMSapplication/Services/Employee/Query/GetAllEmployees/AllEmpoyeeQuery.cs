using HRMSapplication.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Queries.GetAllEmployees
{
    public record AllEmployeeQuery : IRequest<IEnumerable<EmployeeResponse>>;

}
