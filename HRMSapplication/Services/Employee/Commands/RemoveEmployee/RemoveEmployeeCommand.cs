using HRMS.Application.Services.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Commands.RemoveEmployee
{
    public record RemoveEmployeeCommand(Guid Id):IRequest<BaseCommandResponse>;
}
