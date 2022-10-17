using HRMS.Application.Services.Common;
using MediatR;

namespace HRMSapplication.Commands.ApproveLeave
{
    public record ApproveLeaveCommand(Guid ApplyLeaveId, string message):IRequest<BaseCommandResponse>;
}
