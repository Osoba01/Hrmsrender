using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.ApproveLeave
{
    public record ApproveLeaveCommandHandler : IRequestHandler<ApproveLeaveCommand>
    {
        private readonly IApplyLeaveRepo repo;

        public ApproveLeaveCommandHandler(IApplyLeaveRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Unit> Handle(ApproveLeaveCommand request, CancellationToken cancellationToken)
        {
            var applyLeave=await repo.FindAsync(request.ApplyLeaveId);
            if (applyLeave!=null)
            {
                repo.PatchUpdate(applyLeave);
                ApproveCreateLeaveObj(request, applyLeave);
                await repo.Complete();
                return Unit.Value;
            }
            throw new ArgumentException("record not found.");
        }
        private void ApproveCreateLeaveObj(ApproveLeaveCommand command, ApplyLeave applyLeave)
        {
            applyLeave.IsPprove = true;
            applyLeave.ApproverMessage = command.message;
            applyLeave.LastModifyDate = DateTime.Now;
        }
    }
}
