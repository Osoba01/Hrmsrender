using HRMS.Domain.Entities;
using HRMScore.Entities.Base;
using HRMScore.HRMSenums;

namespace HRMScore.Entities
{
    public class Employee:BaseEntity
    {
        //personal Details
        public Employee()
        {
            applyLeaves = new();
            EmployeeProjects=new();
            workExperiences=new();
            companyProjects=new();
            ProjectsTeamLead=new();
        }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? OtherName { get; set; }
        public string? ContactAddress { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? PhoneNo { get; set; }
        public string? TechnicalSkill { get; set; }
        public string? SoftSkill { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DateEmployed { get; set; }
        public string? Nationality { get; set; }
        public byte[]? Photo { get; set; }
        public string? StaffId { get; set; }
        public List<EmployeeProject> EmployeeProjects { get; set; }

        //Next of King Details
        public string? NextOfKingFirstName { get; set; }
        public  string? NextOfKingSurName { get; set; }
        public string? NextOfKingPhoneNo { get; set; }
        public string? NextOfKingAddress { get; set; }
        public string? NextOfKingEmail { get; set; }
        public NextOfKingRelationship? Relationship { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public string? RefreshToken { get; set; }


        //Work Details
        public Employee? Manager { get; set; }
        public Role Role { get; set; }
        public JobRole? JobRole { get; set; }
        public JobLocation? JobLocation { get; set; }
        public Department? Department { get; set; }
        public List<ApplyLeave> applyLeaves { get; set; }
        public List<WorkExperience> workExperiences { get; set; }
        public List<CompanyProject> companyProjects { get; set; }
        public List<CompanyProject> ProjectsTeamLead { get; set; }
        public WorkType? WorkType { get; set; }
        public ContractType? ContractType { get; set; }
        public bool ConfirmedStatus { get; set; }
        public bool RecievedOfferLetter { get; set; }
        public DateTime LastDatePromoted { get; set; }
        public bool IsLock { get; set; }
        public int NTry { get; set; }

        //Maritarn info
    
    }
}
