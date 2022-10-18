using HRMS.Application.Services.EmployeeService.Common;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using HRMScore.HRMSenums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Query.GetEmployeeByRole
{
    public record EmployeeByRoleQuery(Role Role):IRequest<IEnumerable<EmployeeResponse>>;

    internal record EmployeeByRoleQueryHandler : IRequestHandler<EmployeeByRoleQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapEmployee _map;

        public EmployeeByRoleQueryHandler(IEmployeeRepo employeeRepo, IMapEmployee map)
        {
            _employeeRepo = employeeRepo;
            _map = map;
        }
        public async Task<IEnumerable<EmployeeResponse>> Handle(EmployeeByRoleQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _employeeRepo.FindByPredicate(x=>x.Role==request.Role));
        }
    }
}
