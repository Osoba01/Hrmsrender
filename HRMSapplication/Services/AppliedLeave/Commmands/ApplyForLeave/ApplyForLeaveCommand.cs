using HRMS.Application.Services.Common;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.ApplyForLeave
{
    public record ApplyForLeaveCommand(Guid LeaveId, Guid EmployeeId, string Reason,
        DateTime StartDate):IRequest<BaseCommandResponse>;
}
