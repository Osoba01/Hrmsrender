using HRMS.Application.Services.Common;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.ApproveLeave
{
    public record ApproveLeaveCommandHandler : IRequestHandler<ApproveLeaveCommand, BaseCommandResponse>
    {
        private readonly IApplyLeaveRepo repo;

        public ApproveLeaveCommandHandler(IApplyLeaveRepo repo)
        {
            this.repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(ApproveLeaveCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var applyLeave=await repo.FindAsync(request.ApplyLeaveId);
            if (applyLeave!=null)
            {
                repo.PatchUpdate(applyLeave);
                ApproveCreateLeaveObj(request, applyLeave);
                await repo.Complete();
                response.IsSuccess=true;
            }else
                response.Message = "record not found.";
            return response;
        }
        private void ApproveCreateLeaveObj(ApproveLeaveCommand command, ApplyLeave applyLeave)
        {
            applyLeave.IsPprove = true;
            applyLeave.ApproverMessage = command.message;
            applyLeave.LastModifyDate = DateTime.Now;
        }
    }
}
