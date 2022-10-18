using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.RemoveEmployee
{
    public record RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo repo;

        public RemoveEmployeeCommandHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp= await repo.FindAsync(request.Id);
            if (emp != null)
            {
                repo.RemoveEntity(emp);
                await repo.Complete();
                response.IsSuccess = true;
            }
            else
                response.Message="Employee not found.";
            return response;
        }
    }
}
