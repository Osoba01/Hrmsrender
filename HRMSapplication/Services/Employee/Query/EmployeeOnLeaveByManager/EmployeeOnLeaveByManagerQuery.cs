using AutoMapper;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Query.EmployeeOnLeaveByManager
{
    public record EmployeeOnLeaveByManagerQuery(Guid ManagerId):IRequest<List<EmployeeResponse>>;

    internal record EmployeeOnLeaveByManagerQueryHandler : IRequestHandler<EmployeeOnLeaveByManagerQuery, List<EmployeeResponse>>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeOnLeaveByManagerQueryHandler(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }
        public async Task<List<EmployeeResponse>> Handle(EmployeeOnLeaveByManagerQuery request, CancellationToken cancellationToken)
        {


            return _mapper.Map<List<EmployeeResponse>>(await _employeeRepo.EmployeeOnLeaveByManager(request.ManagerId));
        }
    }
}
