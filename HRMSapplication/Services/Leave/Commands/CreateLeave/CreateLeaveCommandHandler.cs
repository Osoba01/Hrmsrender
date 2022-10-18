using AutoMapper;
using HRMS.Application.Services.LeaveService.Common;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.CreateLeave
{
    public record CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, LeaveResponse>
    {
        private readonly ILeaveRepo _repo;
        private readonly IMapLeave _map;

        public CreateLeaveCommandHandler(ILeaveRepo repo, IMapLeave map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<LeaveResponse> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            Leave leave = _repo.AddEntity(_map.CreateCommandToEntity(request));
            await _repo.Complete();
            return _map.EntityToResponse(leave);
        }
    }
}
