using HRMSapplication.Commands.UpdateEmployee;
using HRMSapplication.Response;

namespace HRMS.Application.Services.EmployeeService.Common
{
    public interface IMapEmployee
    {
        //HRMScore.Entities.Employee UpdateCommandToEntity(UpdateEmployeeCommand command);
        EmployeeResponse EntityToResponse(Domain.Entities.Employee entity);
        IEnumerable<EmployeeResponse> EntityToResponse(IEnumerable<Domain.Entities.Employee> entities);
    }
}