using MediatR;

namespace HRMSapplication.Commands.ApproveLeave
{
    public record ApproveLeaveCommand(Guid ApplyLeaveId, string message):IRequest;
}
