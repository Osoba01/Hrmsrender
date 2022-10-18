using HRMS.Application.Utilities;
using HRMS.Domain.IRepositories;
using HRMScore.HRMSenums;
using MediatR;

namespace HRMS.Application.Services.Employee.Query.HrInfo
{
    public record HrInfoCommand:IRequest<HrInfoResponse>;

    public record HrInfoCommandHandler : IRequestHandler<HrInfoCommand, HrInfoResponse>
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IApplyLeaveRepo _applyLeaveRepo;

        public HrInfoCommandHandler(IEmployeeRepo employeeRepo, IApplyLeaveRepo applyLeaveRepo)
        {
            _employeeRepo = employeeRepo;
            _applyLeaveRepo = applyLeaveRepo;
        }
        public async Task<HrInfoResponse> Handle(HrInfoCommand request, CancellationToken cancellationToken)
        {
            var allEmployee=(await _employeeRepo.GetAll()).ToList();
            HrInfoResponse response = new();
            response.TotalEmployee = allEmployee.Count();
            response.TotalMale = allEmployee.Where(x=>x.Gender==Gender.Male).Count();
            response.TotalMarried= allEmployee.Where(x => x.MaritalInfo==MaritalInfo.Married).Count();
            response.TotalFullTimeEmployee = allEmployee.Where(x => x.ContractType == ContractType.FullTime).Count();
            response.TotalActiveEmployee = response.TotalEmployee - await GetTotalActiveEmployee();
            response.DistributionByWorkLocation = GetDistributionByWorkLocation(allEmployee);
            response.DistributionByWorkType = GetDistributionByWorkType(allEmployee);
            response.DistributionByAge = GetDistributionByAge(allEmployee);
            response.DistributionByDepartment = GetDistributionByDepartment(allEmployee);
            response.DistributionByWorkRole = GetDistributionByWorkRole(allEmployee);
            return response;
        }
        async Task<int> GetTotalActiveEmployee()
        {
            return (await _applyLeaveRepo.ApplyLeaveByPredicate(x => x.StartDate.Date <= DateTime.Today &&
            x.StartDate.AddDays(x.Leave.Days) >= DateTime.Today)).Count();
        }
        List<DistributionByWorkLocation> GetDistributionByWorkLocation(List<Domain.Entities.Employee> employees)
        {
            var p = employees.Select(emp=>emp.JobLocation.ToString()).ToList();
            return p.GroupBy(x => x)
                .Select(y => new DistributionByWorkLocation
                {
                    Location = y.Key,
                    NoEmployee = y.Count()
                }).ToList();
            
        }
        List<DistributionByWorkType> GetDistributionByWorkType(List<Domain.Entities.Employee> employees)
        {
            var p = employees.Select(emp => emp.ContractType.ToString()).ToList();
            return p.GroupBy(x => x)
                .Select(y => new DistributionByWorkType
                {
                    WorkType = y.Key,
                    NoEmployee = y.Count()
                }).ToList();
        }
        List<DistributionByDepartment> GetDistributionByDepartment(List<Domain.Entities.Employee> employees)
        {
            employees = employees.Where(x => x.Department!=null).ToList();
            var p = employees.Select(emp => emp.Department.Name);
            return p.GroupBy(x => x)
                .Select(y => new DistributionByDepartment
                {
                    Department = y.Key,
                    NoEmployee = y.Count()
                }).ToList();
        }
        List<DistributionByAge> GetDistributionByAge(List<Domain.Entities.Employee> employees)
        {
            var p = employees.Select(emp =>Logic.GetAge(emp.DOB)).ToList();
            List<DistributionByAge> DistributionByAge = new();
            int R0_20 = 0;
            int R21_25 = 0;
            int R26_30 = 0;
            int R31_40 = 0;
            int R41_50 = 0;
            int R51_60 = 0;
            int R61_70 = 0;
            int R71Up = 0;
            foreach (int age in p)
            {
                if (age<21)
                {
                    R0_20++;
                }else if(age<26)
                {
                    R21_25++;
                }
                else if (age < 31)
                {
                    R26_30++;
                }
                else if (age < 41)
                {
                    R31_40++;
                }
                else if (age < 51)
                {
                    R41_50++;
                }
                else if (age < 61)
                {
                    R51_60++;
                }
                else if (age < 71)
                {
                    R61_70++;
                }else
                  R71Up++;

            }

            DistributionByAge.Add(new DistributionByAge(){ AgeRange = "0-20", NoEmployee = R0_20});
            DistributionByAge.Add(new DistributionByAge() { AgeRange = "21-25", NoEmployee = R21_25 });
            DistributionByAge.Add(new DistributionByAge() { AgeRange = "26-30", NoEmployee = R26_30 });
            DistributionByAge.Add(new DistributionByAge() { AgeRange = "31-40", NoEmployee = R31_40 });
            DistributionByAge.Add(new DistributionByAge() { AgeRange = "41-50", NoEmployee = R41_50 });
            DistributionByAge.Add(new DistributionByAge() { AgeRange = "51-60", NoEmployee = R51_60 });
            DistributionByAge.Add(new DistributionByAge() { AgeRange = "61-70", NoEmployee = R61_70 });
            DistributionByAge.Add(new DistributionByAge() { AgeRange = ">70", NoEmployee = R71Up });

            return DistributionByAge;


        }
        List<DistributionByWorkRole> GetDistributionByWorkRole(List<Domain.Entities.Employee> employees)
        {
            var p = employees.Select(emp => emp.Role.ToString()).ToList();
            return p.GroupBy(x => x)
                .Select(y => new DistributionByWorkRole
                {
                    Role = y.Key,
                    NoEmployee = y.Count()
                }).ToList();
        }
    }
}
