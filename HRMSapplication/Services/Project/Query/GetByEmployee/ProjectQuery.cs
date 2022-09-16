using AutoMapper;
using HRMS.Application.Services.Project.CommonResponse;
using HRMS.Application.Services.ProjectService.Common;
using HRMS.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Project.Query.GetAllProject
{
    public record ProjectQuery(Guid EmployeeId):IRequest<IEnumerable<ProjectResponse>>;

    public record ProjectQueryHandler : IRequestHandler<ProjectQuery, IEnumerable<ProjectResponse>>
    {
        private readonly IProjectRepo _repo;
        private readonly IMapProject _map;

        public ProjectQueryHandler(IProjectRepo repo, IMapProject map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<ProjectResponse>> Handle(ProjectQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return _map.EntityToResponse(await _repo.FindByPredicate(x => x.Employee.Id == request.EmployeeId));
        }
    }
}
