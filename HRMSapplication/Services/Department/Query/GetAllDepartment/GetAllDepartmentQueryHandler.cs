using AutoMapper;
using HRMS.Application.Services.CommonDepartment;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetAllDepartment
{
    public record GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IEnumerable<DepartmentResponse>>
    {
        private readonly IDepartmentRepo _repo;
        private readonly IMapDepartment _map;

        public GetAllDepartmentQueryHandler(IDepartmentRepo repo, IMapDepartment map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<IEnumerable<DepartmentResponse>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            return _map.EntityToResponse(await _repo.GetAll());
        }
    }
}
