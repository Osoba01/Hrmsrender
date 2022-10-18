using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using HRMSapplication.Commands.UpdateEmployee;
using HRMSapplication.Response;
using HRMScore.HRMSenums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.UpdateJobDetails
{
    public record UpdateJobDetailCommand(
        Guid Id, bool ConfirmedStatus, bool RecievedOfferLetter,
        DateTime LastDatePromoted,string StaffId,
        ContractType ContractType, WorkType WorkType,
        JobRole JobRole, JobLocation JobLocation
        ) : IRequest<BaseCommandResponse>;

    internal record UpdateJobDetailCommandHandler : IRequestHandler<UpdateJobDetailCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo _repo;

        public UpdateJobDetailCommandHandler(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(UpdateJobDetailCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var empy = await _repo.FindAsync(request.Id);
            if (empy != null)
            {
                _repo.PatchUpdate(empy);
                UpdateCreateEmployee(request, empy);
                await _repo.Complete();
                response.IsSuccess = true;
            }
            else
                response.Message = "Record not found. Please contact the developer or admin.";
            return response;
        }
        private void UpdateCreateEmployee(UpdateJobDetailCommand request, Domain.Entities.Employee employee)
        {
            employee.LastModifyDate = DateTime.Now;
            employee.ContractType = request.ContractType;
            employee.StaffId = request.StaffId;
            employee.JobRole = request.JobRole;
            employee.RecievedOfferLetter = request.RecievedOfferLetter;
            employee.WorkType = request.WorkType;
            employee.LastDatePromoted = request.LastDatePromoted;
            employee.JobLocation = request.JobLocation;
        }
    }
    
}
   
