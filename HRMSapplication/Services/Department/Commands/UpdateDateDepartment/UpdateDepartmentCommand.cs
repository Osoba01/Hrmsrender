using HRMS.Application.Services.Common;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.UpdateDate
{
    public record UpdateDepartmentCommand(Guid Id, string Name, string Description, Guid HodId) : IRequest<BaseCommandResponse>;
}
