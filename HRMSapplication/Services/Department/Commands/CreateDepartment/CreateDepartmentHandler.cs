using AutoMapper;
using HRMS.Application.Services.CommonDepartment;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.CreateDepartment
{
    public record CreateDepartmentHandler : IRequestHandler<CreateDepartmentCommand, DepartmentResponse>
    {
        private readonly IDepartmentRepo _deptRep;
        private readonly IMapDepartment _map;

        public CreateDepartmentHandler(IDepartmentRepo deptRep, IMapDepartment map)
        {
            _deptRep = deptRep;
            _map = map;
        }
        public async Task<DepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department dept= _map.CreateCommandToEntity(request);
            _deptRep.AddEntity(dept);
            await _deptRep.Complete();
            return _map.EntityToResponse(dept);
        }
    }
}
