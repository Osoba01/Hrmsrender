using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.RejectOrCancleLeave
{
    public record RejectOrConcleLeaveCommandHandler : IRequestHandler<RejectOrConcleLeaveCommand>
    {
        private readonly IApplyLeaveRepo repo;

        public RejectOrConcleLeaveCommandHandler(IApplyLeaveRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Unit> Handle(RejectOrConcleLeaveCommand request, CancellationToken cancellationToken)
        {
            var appliedLeave = await repo.FindAsync(request.ApplyLeaveId);
            if (appliedLeave != null)
            {
                repo.PatchUpdate(appliedLeave);
                RejectLeaveObj(appliedLeave, request);
                await repo.Complete();
                return Unit.Value;
            }
            else
                throw new ArgumentException("Record not found.");
            
        }
        private void RejectLeaveObj(ApplyLeave appliedLeave, RejectOrConcleLeaveCommand command)
        {
            appliedLeave.IsReject=true;
            appliedLeave.ApproverMessage = command.message;
            appliedLeave.LastModifyDate = DateTime.Now;
        }
    }
}
