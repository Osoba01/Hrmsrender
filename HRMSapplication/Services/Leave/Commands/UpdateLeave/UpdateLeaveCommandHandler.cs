using AutoMapper;
using HRMS.Application.Services.Common;
using HRMS.Application.Services.LeaveService.Common;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.UpdateLeave
{
    public record UpdateLeaveCommandHandler : IRequestHandler<UpdateLeaveCommand, BaseCommandResponse>
    {
        private readonly ILeaveRepo _repo;
        private readonly IMapLeave _map;

        public UpdateLeaveCommandHandler(ILeaveRepo repo, IMapLeave map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var leave = await _repo.FindAsync(request.Id);
            if (leave is not null)
            {
                UpdateCreateLeave(request, leave);
                _repo.Update(leave);
                await _repo.Complete();
                response.IsSuccess=true;
            }
            else
                response.Message="Record not found";
            return response;
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
