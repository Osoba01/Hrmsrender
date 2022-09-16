using AutoMapper;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.RateEmployeePerformance
{
    public record RateEmployeePerformanceCommandHandler : IRequestHandler<RateEmployeePerformanceCommand, PerformanceResponse>
    {
        private readonly IPerformanceRepo repo;
        private readonly IMapper map;
        private readonly IEmployeeRepo empRepo;

        public RateEmployeePerformanceCommandHandler(IPerformanceRepo repo, IEmployeeRepo empRepo, IMapper map)
        {
            this.repo = repo;
            this.empRepo = empRepo;
            this.map= map;
        }
        public async Task<PerformanceResponse> Handle(RateEmployeePerformanceCommand request, CancellationToken cancellationToken)
        {
            var emp = (await empRepo.FindByPredicate(x => x.Id == request.EmployeeId)).FirstOrDefault();
            if (emp != null)
            {
                Performance performance = new Performance() { Month = request.Month, MonthlyRating = request.MonthlyRating, Employee = emp };
                repo.AddEntity(performance);
                await repo.Complete();
                return map.Map<PerformanceResponse>(performance);
            }
            else
                throw new ArgumentException("Employee record not found.");
        }
        
    }
}
