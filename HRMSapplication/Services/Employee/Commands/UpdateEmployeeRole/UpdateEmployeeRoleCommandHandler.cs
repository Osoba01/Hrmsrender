using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.UpdateEmployeeDepartment
{
    public record UpdateEmployeeRoleCommandHandler : IRequestHandler<UpdateEmployeeRoleCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo repo;

        public UpdateEmployeeRoleCommandHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(UpdateEmployeeRoleCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp= await repo.FindAsync(request.EmployeeId);
            if (emp is not null)
            {
                repo.PatchUpdate(emp);
                emp.Role=request.Role;
                await repo.Complete();
                response.IsSuccess=true;
            }
            else
                response.Message="Employee not found.";
            return response;
        }
    }
}
