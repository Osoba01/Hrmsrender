using AutoMapper;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeePerformance
{
    public record EmployeePerformanceQueryHandler : IRequestHandler<EmployeePerformanceQuery, IEnumerable<PerformanceResponse>>
    {
        private readonly IPerformanceRepo repo;
        private readonly IMapper map;

        public EmployeePerformanceQueryHandler(IPerformanceRepo repo, IMapper map)
        {
            this.repo = repo;
            this.map = map;
        }
        public async Task<IEnumerable<PerformanceResponse>> Handle(EmployeePerformanceQuery request, CancellationToken cancellationToken)
        {
            return map.Map<IEnumerable<PerformanceResponse>>(await repo.FindByPredicate(x => x.Employee.Id==request.EmpoyeeId));
        }
    }
}
