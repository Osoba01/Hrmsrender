using AutoMapper;
using HRMS.Application.Services.Common;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.UpdateDate
{
    public record UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BaseCommandResponse>
    {
        private readonly IDepartmentRepo _repo;
        private readonly IEmployeeRepo _employeeRepo;

        public UpdateDepartmentCommandHandler(IDepartmentRepo repo, IEmployeeRepo employeeRepo)
        {
            _repo = repo;
            _employeeRepo = employeeRepo;
        }
        public async Task<BaseCommandResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse resp = new();
            var dept= await _repo.FindAsync(request.Id);
            if (dept != null)
            {
                CreateDepartment(request, dept);
                var hod = await _employeeRepo.FindAsync(request.HodId);
                if (hod != null)
                    dept.HOD = hod;
                _repo.Update(dept);
                await _repo.Complete();
                resp.IsSuccess = true;
            }
            else
                resp.Message="Department not found.";
            return resp;
        }
        public void CreateDepartment(UpdateDepartmentCommand request, Department dept)
        {
            dept.Name = request.Name;
            dept.Description = request.Description;
            dept.LastModifyDate = DateTime.UtcNow;
        }
    }
}
