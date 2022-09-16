using AutoMapper;
using HRMS.Application.Services;
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.ApplyForLeave
{
    public record ApplyForLeaveCommandHandler : IRequestHandler<ApplyForLeaveCommand, ApplyLeaveResponse>
    {
        private readonly IApplyLeaveRepo _repo;
        private readonly IMapApplyLeave _map;

        public ApplyForLeaveCommandHandler(IApplyLeaveRepo repo, IMapApplyLeave map)
        {
            _repo = repo;
            _map = map;
  
        }
        public async Task<ApplyLeaveResponse> Handle(ApplyForLeaveCommand request, CancellationToken cancellationToken)
        {
            
            ApplyLeave newApp= _repo.AddEntity(_map.CreateCommandToEntity(request));
            await _repo.Complete();
            return _map.EntityToResponse(newApp);
        }

    }
}
