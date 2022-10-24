using AutoMapper;
using HRMS.Application.Services;
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMS.Application.Services.Common;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Commands.ApplyForLeave
{
    public record ApplyForLeaveCommandHandler : IRequestHandler<ApplyForLeaveCommand, BaseCommandResponse>
    {
        private readonly IApplyLeaveRepo _repo;
        private readonly IMapApplyLeave _map;
        private readonly IEmployeeRepo _employeeRepo;
        private readonly ILeaveRepo _leaveRepo;

        public ApplyForLeaveCommandHandler(IApplyLeaveRepo repo, IMapApplyLeave map, IEmployeeRepo employeeRepo, ILeaveRepo leaveRepo)
        {
            _repo = repo;
            _map = map;
            _employeeRepo = employeeRepo;
            _leaveRepo = leaveRepo;
        }
        public async Task<BaseCommandResponse> Handle(ApplyForLeaveCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp = await _employeeRepo.FindAsync(request.EmployeeId);
            if (emp is not null)
            {
                var leave = await _leaveRepo.FindAsync(request.LeaveId);
                if (leave is not null)
                {
                    ApplyLeave newApp = _repo.AddEntity(_map.CreateCommandToEntity(request));
                    newApp.Leave = leave;
                    newApp.Employee = emp;
                    _repo.AddEntity(newApp);
                    await _repo.Complete();
                    response.IsSuccess=true;
                }
                else
                    response.Message = "This leave you are applying for does not exist in the record";
            }
            else
                response.Message = "Employee does not exist";
            return response;
           
        }

    }
}
