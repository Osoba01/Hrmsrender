
using HRMS.Domain.Entities;
using HRMSapplication.Response.Base;
using HRMScore.HRMSenums;
using static HRMS.Application.Utilities.Logic;


namespace HRMSapplication.Response
{
    public class EmployeeResponse:BaseResponse
    {
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? OtherName { get; set; }
        public string? ContactAddress { get; set; }
        public DateTime DOB { get; set; }
        public int Age
        {
            get { 
                return GetAge(DOB);
            }
        }
        public MaritalInfo MaritalInfo { get; set; }
        public DateTime? DateEmployed { get; set; }
        public string? Nationality { get; set; }
        public DateTime? LastDatePromoted { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? PhoneNo { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }

        //Next of King Details
        public string? NextOfKingFirstName { get; set; }
        public string? NextOfKingSurName { get; set; }
        public string? NextOfKingPhoneNo { get; set; }
        public string? NextOfKingAddress { get; set; }
        public string? NextOfKingEmail { get; set; }
        public NextOfKingRelationship? Relationship { get; set; }


        //Work Details
        public JobLocation? JobLocation { get; set; }
        public string? Manager { get; set; }
        public string? StaffId { get; set; }
        public Role? Role { get; set; }
        public JobRole? JobRole { get; set; }
        public string? DepartmentName { get; set; }
        public WorkType? WorkType { get; set; }
        public ContractType? ContractType { get; set; }
        public bool ConfirmedStatus { get; set; }
        public bool RecievedOfferLetter { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<CompanyProject> CompanyProjects { get; set; }
    }
}
