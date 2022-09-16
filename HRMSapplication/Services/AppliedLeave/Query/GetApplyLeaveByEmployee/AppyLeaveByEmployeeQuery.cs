using HRMSapplication.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Queries.GetApplyLeaveByEmployee
{
    public record AppyLeaveByEmployeeQuery(Guid EmployeeId):IRequest<IEnumerable<ApplyLeaveResponse>>;
}
