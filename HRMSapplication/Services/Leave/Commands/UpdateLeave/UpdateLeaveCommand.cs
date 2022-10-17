using HRMS.Application.Services.Common;
using HRMSapplication.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Commands.UpdateLeave
{
    public record UpdateLeaveCommand(Guid Id,string Name,int Days ,decimal Allowance):IRequest<BaseCommandResponse>;
}
