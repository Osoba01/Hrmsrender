using AutoMapper;
using HRMS.Application.Services.Common;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.RateEmployeePerformance
{
    public record RateEmployeePerformanceCommandHandler : IRequestHandler<RateEmployeePerformanceCommand, BaseCommandResponse>
    {
        private readonly IPerformanceRepo repo;
        private readonly IEmployeeRepo empRepo;

        public RateEmployeePerformanceCommandHandler(IPerformanceRepo repo, IEmployeeRepo empRepo)
        {
            this.repo = repo;
            this.empRepo = empRepo;
        }
        public async Task<BaseCommandResponse> Handle(RateEmployeePerformanceCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp = (await empRepo.FindByPredicate(x => x.Id == request.EmployeeId)).FirstOrDefault();
            if (emp != null)
            {
                Performance performance = new Performance() { Month = request.Month, MonthlyRating = request.MonthlyRating, Employee = emp };
                repo.AddEntity(performance);
                await repo.Complete();
                response.IsSuccess = true;
                
            }
            else
                response.Message="Employee record not found.";
            return response;
        }
        
    }
}
