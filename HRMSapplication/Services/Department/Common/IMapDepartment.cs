using HRMSapplication.Commands.CreateDepartment;
using HRMSapplication.Response;
using HRMScore.Entities;

namespace HRMS.Application.Services.CommonDepartment
{
    public interface IMapDepartment
    {
        DepartmentResponse EntityToResponse(Department entity);
        IEnumerable<DepartmentResponse> EntityToResponse(IEnumerable<Department> entities);
        Department CreateCommandToEntity(CreateDepartmentCommand command);
    }
}