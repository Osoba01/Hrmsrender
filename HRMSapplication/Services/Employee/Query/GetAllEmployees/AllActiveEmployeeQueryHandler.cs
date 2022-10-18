using AutoMapper;
using HRMS.Application.Services.EmployeeService.Common;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetAllEmployees
{
    public record AllActiveEmployeeQueryHandler : IRequestHandler<AllEmployeeQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapEmployee _map;

        public AllActiveEmployeeQueryHandler(IEmployeeRepo repo, IMapEmployee map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<EmployeeResponse>> Handle(AllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.GetAll());
        }
    }

}
