using AutoMapper;
using HRMS.Application.Services.LeaveService.Common;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.UpdateLeave
{
    public record UpdateLeaveCommandHandler : IRequestHandler<UpdateLeaveCommand, LeaveResponse>
    {
        private readonly ILeaveRepo _repo;
        private readonly IMapLeave _map;

        public UpdateLeaveCommandHandler(ILeaveRepo repo, IMapLeave map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<LeaveResponse> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
        {
            var leave = await _repo.FindAsync(request.Id);
            if (leave is not null)
            {
                UpdateCreateLeave(request, leave);
                _repo.Update(leave);
                await _repo.Complete();
                return _map.EntityToResponse(leave);
            }
            else
                throw new ArgumentException("Record not found");
        }
        private void UpdateCreateLeave(UpdateLeaveCommand request, Leave leave)
        {
            leave.Name=request.Name;
            leave.Days = request.Days;
            leave.Allowance = request.Allowance;
            leave.LastModifyDate = DateTime.Now;
        }
    }
}
