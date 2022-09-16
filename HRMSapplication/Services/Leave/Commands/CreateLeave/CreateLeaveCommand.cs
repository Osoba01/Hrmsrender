using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.CreateLeave
{
    public record CreateLeaveCommand(string Name, int Days, decimal Allowance):IRequest<LeaveResponse>;
}
