using AutoMapper;
using HRMS.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.EmployeeProject.Query
{
    public record EmployeeProjectQuery(Guid EmployeeId):IRequest<List<EmployeeProjectResponse>>;

    public record EmployeeProjectQueryHandler : IRequestHandler<EmployeeProjectQuery, List<EmployeeProjectResponse>>
    {
        private readonly IEmployeeProjectRepo _repo;
        private readonly IMapper _mapper;

        public EmployeeProjectQueryHandler(IEmployeeProjectRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<EmployeeProjectResponse>> Handle(EmployeeProjectQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<EmployeeProjectResponse>>(await _repo.FindByPredicate(x => x.Employee.Id == request.EmployeeId));
        }
    }
}
