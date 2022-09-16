using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.UpdateEmployeeDepartment
{
    public record UpdateEmployeeRoleCommandHandler : IRequestHandler<UpdateEmployeeRoleCommand>
    {
        private readonly IEmployeeRepo repo;

        public UpdateEmployeeRoleCommandHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Unit> Handle(UpdateEmployeeRoleCommand request, CancellationToken cancellationToken)
        {
            var emp= await repo.FindAsync(request.EmployeeId);
            if (emp is not null)
            {
                repo.PatchUpdate(emp);
                emp.Role=request.Role;
                await repo.Complete();
                return Unit.Value;
            }
            else
                throw new ArgumentException("Employee not found.");
        }
    }
}
