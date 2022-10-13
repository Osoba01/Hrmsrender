using HRMS.Application.Services.WorkExparience.CommonResponse;
using HRMS.Application.Services.WorkExparienceService.Common;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMS.Application.Services.WorkExparience.Query.GetWorkExperienceByEmployee
{
    public record WorkExperienceByEmployeeQuery(Guid EmployeeId):IRequest<IEnumerable<ExperienceResponse>>;

    public record GetWorkExperienceByEmployeeQueryHandler : IRequestHandler<WorkExperienceByEmployeeQuery, IEnumerable<ExperienceResponse>>
    {
        private readonly IWorkExperienceRepo _repo;
        private readonly IMapWorkExperience _map;

        public GetWorkExperienceByEmployeeQueryHandler(IWorkExperienceRepo repo, IMapWorkExperience map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<ExperienceResponse>> Handle(WorkExperienceByEmployeeQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.FindByPredicate(x => x.Employee.Id == request.EmployeeId));
        }
    }
}
