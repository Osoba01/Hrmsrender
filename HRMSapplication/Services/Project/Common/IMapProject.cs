using HRMS.Application.Services.Project.Command.CreateProject;
using HRMS.Application.Services.Project.CommonResponse;
using HRMS.Domain.Entities;

namespace HRMS.Application.Services.ProjectService.Common
{
    public interface IMapProject
    {
        ProjectResponse EntityToResponse(CompanyProject entity);
        IEnumerable<ProjectResponse> EntityToResponse(IEnumerable<CompanyProject> entities);
        CompanyProject CreateCommandToEntity(CreateProjectCommand command);
    }
}