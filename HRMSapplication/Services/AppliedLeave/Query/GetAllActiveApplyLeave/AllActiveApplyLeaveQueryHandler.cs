using AutoMapper;
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMSapplication.Response;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Queries.GetAllActiveApplyLeave
{
    public record AllActiveApplyLeaveQueryHandler : IRequestHandler<AllActiveAppyLeaveQuery, IEnumerable<ApplyLeaveResponse>>
    {
        private readonly IApplyLeaveRepo _repo;
        private readonly IMapApplyLeave _map;

        public AllActiveApplyLeaveQueryHandler(IApplyLeaveRepo repo, IMapApplyLeave map)
        {
            _repo = repo;
            _map = map;
        }

        public async Task<IEnumerable<ApplyLeaveResponse>> Handle(AllActiveAppyLeaveQuery request, CancellationToken cancellationToken)
        {
            var p =await _repo.FindByPredicate(x => x.CreateDate.Date <= DateTime.Today &&
              x.StartDate.Date >= DateTime.Today);
    
            return (_map.EntityToResponse(p));
        }
    }
}
