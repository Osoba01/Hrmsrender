using HRMSapplication.Response;
using HRMScore.HRMSenums;
using MediatR;

namespace HRMSapplication.Commands.UpdateEmployee
{
    public record UpdateEmployeeCommand(
        Guid Id, string FirstName, string Surname,
        string ContactAddress, string StateOfOrigin, string PhoneNo, DateTime DOB,
        string Nationality, bool ConfirmedStatus, bool RecievedOfferLetter,
        string NextOfKingFirstName, string NextOfKingSurName,
        string NextOfKingPhoneNo, string NextOfKingEmail,DateTime DateEmployed,
        string NextOfKingAddress, DateTime LastDatePromoted,
        ContractType ContractType, WorkType WorkType, Gender Gender,
        JobRole JobRole,JobLocation JobLocation,
        NextOfKingRelationship Relationship, MaritalInfo MaritalInfo
        )
        : IRequest<EmployeeResponse>
    {
        public Guid? ManagerId { get; set; }
        public string? OtherName { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? StaffId { get; set; }
    }
}
