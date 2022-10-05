using HRMScore.HRMSenums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Query.HrInfo
{
    public class HrInfoResponse
    {
        public HrInfoResponse()
        {
            DistributionByWorkLocation = new();
            DistributionByWorkType= new();
            DistributionByAge = new();
            DistributionByDepartment = new();
            DistributionByWorkRole=new();
        }
        public int TotalEmployee { get; set; }

        public int TotalMale { get; set; }
        public int TotalFemale
        {
            get { return TotalEmployee-TotalMale; }
        }

        public int TotalMarried { get; set; }
        public int TotalSingle
        {
            get { return TotalEmployee- TotalMarried; }
        }

        public int TotalFullTimeEmployee { get; set; }
        public int TotalPartTimeEmployee
        {
            get { return TotalEmployee - TotalFullTimeEmployee; }
        }
        public int TotalActiveEmployee { get; set; }
        public int TotalInActiveEmployee { get { return TotalEmployee - TotalActiveEmployee; } }
        
        public List<DistributionByWorkLocation> DistributionByWorkLocation { get; set; }
        public List<DistributionByWorkType> DistributionByWorkType { get; set; }
        public List<DistributionByAge> DistributionByAge { get; set; }
        public List<DistributionByDepartment> DistributionByDepartment { get; set; }
        public List<DistributionByWorkRole> DistributionByWorkRole { get; set; }
    }
    public class DistributionByWorkLocation
    {
        public string Location { get; set; }
        public int NoEmployee { get; set; }
    }
    public class DistributionByWorkType
    {
        public string WorkType { get; set; }
        public int NoEmployee { get; set; }
    }
    public class DistributionByAge
    {
        public string AgeRange { get; set; }
        public int NoEmployee { get; set; }
    }
    public class DistributionByDepartment
    {
        public string Department { get; set; }
        public int NoEmployee { get; set; }
    }
    public class DistributionByWorkRole
    {
        public string Role { get; set; }
        public int NoEmployee { get; set; }
    }
}
