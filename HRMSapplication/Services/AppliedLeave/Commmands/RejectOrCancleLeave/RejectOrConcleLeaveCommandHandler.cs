using HRMS.Application.Services.Common;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.RejectOrCancleLeave
{
    public record RejectOrConcleLeaveCommandHandler : IRequestHandler<RejectOrConcleLeaveCommand, BaseCommandResponse>
    {
        private readonly IApplyLeaveRepo repo;

        public RejectOrConcleLeaveCommandHandler(IApplyLeaveRepo repo)
        {
            this.repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(RejectOrConcleLeaveCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var appliedLeave = await repo.FindAsync(request.ApplyLeaveId);
            if (appliedLeave != null)
            {
                repo.PatchUpdate(appliedLeave);
                RejectLeaveObj(appliedLeave, request);
                await repo.Complete();
                response.IsSuccess=true;
            }
            else
                response.Message="Record not found.";
            return response;
            
        }
        private void RejectLeaveObj(ApplyLeave appliedLeave, RejectOrConcleLeaveCommand command)
        {
            appliedLeave.IsReject=true;
            appliedLeave.ApproverMessage = command.message;
            appliedLeave.LastModifyDate = DateTime.Now;
        }
    }
}
