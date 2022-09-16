using MediatR;

namespace HRMSapplication.Commands.ChangePassword
{
    public record ChangePasswordCommand(Guid EmployeeId, string NewPassword, string OldPassword) : IRequest<bool>;
    
}
