using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.RemoveEmployee
{
    public record RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand>
    {
        private readonly IEmployeeRepo repo;

        public RemoveEmployeeCommandHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Unit> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp= await repo.FindAsync(request.Id);
            if (emp != null)
            {
                repo.RemoveEntity(emp);
                await repo.Complete();
                return Unit.Value;
            }
            else
                throw new ArgumentException("Employee not found.");
            
        }
    }
}
