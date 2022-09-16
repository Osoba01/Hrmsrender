using HRMSapplication.Commands.UpdateEmployee;
using HRMSapplication.Response;
using HRMScore.Entities;

namespace HRMS.Application.Services.EmployeeService.Common
{
    public interface IMapEmployee
    {
        //HRMScore.Entities.Employee UpdateCommandToEntity(UpdateEmployeeCommand command);
        EmployeeResponse EntityToResponse(HRMScore.Entities.Employee entity);
        IEnumerable<EmployeeResponse> EntityToResponse(IEnumerable<HRMScore.Entities.Employee> entities);
    }
}