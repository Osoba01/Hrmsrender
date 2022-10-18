using AutoMapper;
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetApplyLeaveByEmployee
{
    public record AppyLeaveByEmployeeQueryHandler : IRequestHandler<AppyLeaveByEmployeeQuery, IEnumerable<ApplyLeaveResponse>>
    {
        private readonly IApplyLeaveRepo _repo;
        private readonly IMapApplyLeave _map;

        public AppyLeaveByEmployeeQueryHandler(IApplyLeaveRepo repo, IMapApplyLeave map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<ApplyLeaveResponse>> Handle(AppyLeaveByEmployeeQuery request, CancellationToken cancellationToken)
        {
            var apply= await _repo.ApplyLeaveByPredicate(x=>x.Employee.Id==request.EmployeeId);
            return _map.EntityToResponse(apply);
        }
    }
}
