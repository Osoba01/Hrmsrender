using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.CreateDepartment
{
    public record CreateDepartmentCommand(string Name,string Description): IRequest<DepartmentResponse>;
}
