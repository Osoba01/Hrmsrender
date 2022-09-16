using AutoMapper;
using HRMS.Application.Services.CommonDepartment;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.UpdateDate
{
    public record UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentResponse>
    {
        private readonly IDepartmentRepo _repo;
        private readonly IMapDepartment _map;
        private readonly IEmployeeRepo _employeeRepo;

        public UpdateDepartmentCommandHandler(IDepartmentRepo repo, IMapDepartment map, IEmployeeRepo employeeRepo)
        {
            _repo = repo;
            _map = map;
            _employeeRepo = employeeRepo;
        }
        public async Task<DepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var dept= await _repo.FindAsync(request.Id);
            if (dept != null)
            {
                CreateDepartment(request, dept);
                var hod = await _employeeRepo.FindAsync(request.HodId);
                if (hod != null)
                    dept.HOD = hod;
                _repo.Update(dept);
                await _repo.Complete();
                return _map.EntityToResponse(dept);
            }
            else
                throw new ArgumentException("Record not found.");
        }
        public void CreateDepartment(UpdateDepartmentCommand request, Department dept)
        {
            dept.Name = request.Name;
            dept.Description = request.Description;
            dept.LastModifyDate = DateTime.UtcNow;
        }
    }
}
