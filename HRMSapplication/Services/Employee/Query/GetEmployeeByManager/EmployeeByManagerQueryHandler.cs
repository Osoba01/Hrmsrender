using AutoMapper;
using HRMS.Application.Services.EmployeeService.Common;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeeByDepartment
{
    public record EmployeeByManagerQueryHandler : IRequestHandler<EmployeeByManagerQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapEmployee _map;

        public EmployeeByManagerQueryHandler(IEmployeeRepo repo, IMapEmployee map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<EmployeeResponse>> Handle(EmployeeByManagerQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.EmployeeByManager(request.ManagerId));
        }
    }
}
