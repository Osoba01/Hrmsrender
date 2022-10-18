using AutoMapper;
using HRMS.Application.Services.LeaveService.Common;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetAllLeave
{
    public record AllLeaveQueryHandler : IRequestHandler<AllLeaveQuery,List<LeaveResponse>>
    {
        private readonly ILeaveRepo _repo;
        private readonly IMapLeave _map;

        public AllLeaveQueryHandler(ILeaveRepo repo, IMapLeave map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<List<LeaveResponse>> Handle(AllLeaveQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.GetAll()).ToList();
        }
    }
}
