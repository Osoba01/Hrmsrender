using AutoMapper;
using HRMSapplication.Response;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeeAnualPerformanceRate
{
    public record EmployeeAnualPerformanceQueryHandler : IRequestHandler<EmployeeAnualPerformanceQuery, IEnumerable<PerformanceResponse>>
    {
        private readonly IPerformanceRepo repo;
        private readonly IMapper map;

        public EmployeeAnualPerformanceQueryHandler(IPerformanceRepo repo, IMapper map)
        {
            this.repo = repo;
            this.map = map;
        }
        public async Task<IEnumerable<PerformanceResponse>> Handle(EmployeeAnualPerformanceQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
