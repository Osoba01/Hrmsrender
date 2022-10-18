using AutoMapper;
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
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
            return _map.EntityToResponse(await _repo.OnGoingLeave());
        }
    }
}
