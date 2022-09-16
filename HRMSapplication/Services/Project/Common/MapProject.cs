using AutoMapper;
using HRMS.Application.Services.Project.Command.CreateProject;
using HRMS.Application.Services.Project.CommonResponse;
using HRMS.Domain.Entities;

namespace HRMS.Application.Services.ProjectService.Common
{
    public class MapProject : IMapProject
    {
        private readonly IMapper _map;

        public MapProject(IMapper map)
        {
            _map = map;
        }
        public ProjectResponse EntityToResponse(CompanyProject entity)
        {
            return _map.Map<ProjectResponse>(entity);
        }
        public IEnumerable<ProjectResponse> EntityToResponse(IEnumerable<CompanyProject> entities)
        {
            return _map.Map<IEnumerable<ProjectResponse>>(entities);
        }
        public CompanyProject CreateCommandToEntity(CreateProjectCommand command)
        {
            return _map.Map<CompanyProject>(command);
        }
    }
}
