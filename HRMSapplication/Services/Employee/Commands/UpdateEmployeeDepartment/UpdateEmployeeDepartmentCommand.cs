using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.UpdateEmployeeDepartment
{
    public record UpdateEmployeeDepartmentCommand(Guid EmployId, Guid DepartmentId):IRequest<BaseCommandResponse>;

    internal record UpdateEmployeeDeptartmentCommandHandler : IRequestHandler<UpdateEmployeeDepartmentCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IDepartmentRepo _departmentRepoRepo;

        public UpdateEmployeeDeptartmentCommandHandler(IEmployeeRepo repo, IDepartmentRepo departmentRepoRepo)
        {
            _repo = repo;
            _departmentRepoRepo = departmentRepoRepo;
        }
        public async Task<BaseCommandResponse> Handle(UpdateEmployeeDepartmentCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp = await _repo.FindAsync(request.EmployId);
            if (emp != null)
            {
                var dept = await _departmentRepoRepo.FindAsync(request.DepartmentId);
                if (dept != null)
                {
                    _repo.PatchUpdate(emp);
                    emp.Department = dept;
                    await _repo.Complete();
                    response.IsSuccess = true;
                }
                else
                    response.Message = "Depart not found.";
            }
            else
                response.Message = "Employee is not found.";
            return response;
        }
    }
}
