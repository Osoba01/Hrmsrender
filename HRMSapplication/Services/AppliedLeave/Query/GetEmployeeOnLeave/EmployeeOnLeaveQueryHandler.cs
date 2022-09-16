using AutoMapper;
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMSapplication.Response;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeeOnLeave
{
    public record EmployeeOnLeaveQueryHandler : IRequestHandler<EmployeeOnLeaveQuery, IEnumerable<ApplyLeaveResponse>>
    {
        private readonly IApplyLeaveRepo _repo;
        private readonly IMapApplyLeave _map;

        public EmployeeOnLeaveQueryHandler(IApplyLeaveRepo repo, IMapApplyLeave map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<ApplyLeaveResponse>> Handle(EmployeeOnLeaveQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.ApplyLeaveByPredicate((x => x.StartDate.Date <= DateTime.Today &&
            x.StartDate.AddDays(x.Leave.Days) >= DateTime.Today)));
        }
    }
}
