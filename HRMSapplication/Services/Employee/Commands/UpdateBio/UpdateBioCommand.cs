using HRMS.Application.Services.Common;
using HRMS.Application.Services.EmployeeService.Common;
using HRMS.Domain.IRepositories;
using HRMSapplication.Commands.UpdateEmployee;
using HRMScore.HRMSenums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.UpdateBio
{
    public record UpdateBioCommand(
         Guid Id, string FirstName, string Surname, string OtherName,
        string ContactAddress, string StateOfOrigin, string PhoneNo, DateTime DOB,
        string Nationality,
        string NextOfKingFirstName, string NextOfKingSurName,
        string NextOfKingPhoneNo, string NextOfKingEmail,
        string NextOfKingAddress, Gender Gender,
        NextOfKingRelationship Relationship, MaritalInfo MaritalInfo
        ) :IRequest<BaseCommandResponse>;

    internal record UpdateBioCommandHandler : IRequestHandler<UpdateBioCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo _repo;

        public UpdateBioCommandHandler(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(UpdateBioCommand request, CancellationToken cancellationToken)
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
        private void UpdateCreateEmployee(UpdateBioCommand request, Domain.Entities.Employee employee)
        {
            employee.Nationality = request.Nationality;
            employee.ContactAddress = request.ContactAddress;
            employee.DOB = request.DOB;
            employee.FirstName = request.FirstName;
            employee.Surname = request.Surname;
            employee.OtherName = request.OtherName;
            employee.Gender = request.Gender;
            employee.PhoneNo = request.PhoneNo;
            employee.MaritalInfo = request.MaritalInfo;
            employee.StateOfOrigin = request.StateOfOrigin;
            employee.LastModifyDate = DateTime.Now;

            employee.NextOfKingPhoneNo = request.NextOfKingPhoneNo;
            employee.NextOfKingEmail = request.NextOfKingEmail;
            employee.NextOfKingSurName = request.NextOfKingSurName;
            employee.NextOfKingFirstName = request.NextOfKingFirstName;
            employee.NextOfKingAddress = request.NextOfKingAddress;
            employee.Relationship = request.Relationship;

        }
    }
}
