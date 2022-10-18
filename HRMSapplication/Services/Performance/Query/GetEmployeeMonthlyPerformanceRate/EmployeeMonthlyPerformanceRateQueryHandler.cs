using AutoMapper;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeeMonthlyPerformanceRate
{
    public record EmployeeMonthlyPerformanceRateQueryHandler : IRequestHandler<EmployeeMonthlyPerformanceRateQuery, IEnumerable<PerformanceResponse>>
    {
        private readonly IPerformanceRepo repo;
        private readonly IMapper map;

        public EmployeeMonthlyPerformanceRateQueryHandler(IPerformanceRepo repo, IMapper map)
        {
            this.repo = repo;
            this.map = map;
        }
        public Task<IEnumerable<PerformanceResponse>> Handle(EmployeeMonthlyPerformanceRateQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
