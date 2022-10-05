using HRMS.Application.Commands.CreateEmployee;
using HRMSapplication.Response;
using HRMScore.HRMSenums;
using MediatR;

namespace HRMSapplication.Commands.CreateEmployee
{
    public record CreateEmployeeCommand(string Email, Role Role, Guid DepartmentId) :IRequest<CreateEmployeeResponse>;
    
}
