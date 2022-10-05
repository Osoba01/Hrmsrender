using AutoMapper;
using HRMS.Application.Services.Project.CommonResponse;
using HRMS.Application.Services.ProjectService.Common;
using HRMS.Domain.IRepositories;
using MediatR;


namespace HRMS.Application.Services.Project.Query.GetAllProject
{
    public record ProjectMyManagerQuery(Guid EmployeeId):IRequest<IEnumerable<ProjectResponse>>;

    public record ProjectQueryHandler : IRequestHandler<ProjectMyManagerQuery, IEnumerable<ProjectResponse>>
    {
        private readonly IProjectRepo _repo;
        private readonly IMapProject _map;

        public ProjectQueryHandler(IProjectRepo repo, IMapProject map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<ProjectResponse>> Handle(ProjectMyManagerQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.ProjectsByManager(request.EmployeeId));
        }
    }
}
