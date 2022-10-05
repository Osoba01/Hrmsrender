using AutoMapper;
using HRMS.Application.Commands.CreateEmployee;
using HRMS.Application.ISecurityService;
using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMSapplication.Response;
using HRMScore.Entities;
using HRMScore.IRepositories;
using MediatR;

namespace HRMSapplication.Commands.CreateEmployee
{
    public record CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>, ISendEmailEvent
    {
        private readonly IEmployeeRepo repo;
        private readonly IMapper map;
        private readonly ITokenManager _token;
        private readonly IEncryption encrypt;
        private readonly IDepartmentRepo _departmentRepo;

        public CreateEmployeeCommandHandler(IEmployeeRepo repo, IMapper map, ITokenManager token,IEncryption encrypt, IDepartmentRepo departmentRepo)
        {
            this.repo = repo;
            this.map = map;
            _token = token;
            this.encrypt = encrypt;
            _departmentRepo = departmentRepo;
        }

        public event EventHandler<EmployeeEventArg> EmployeeCreated;

        public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var empByEmail=await repo.FindByPredicate(x => x.Email == request.Email.ToLower());
            CreateEmployeeResponse emp = new();
            if (!empByEmail.Any())
            {

                var employee = map.Map<Employee>(request);
                string verificationlink = _token.CreateRandomToken();
                string password = encrypt.GetRandomPassword(9);
                encrypt.EncryptPasswordAsync(employee, password);
                employee.VerificationToken = verificationlink;
                employee.VerifiedAt = DateTime.Now;
                employee.Email = request.Email.ToLower();
                var dept = await _departmentRepo.FindAsync(request.DepartmentId);
                if (dept is not null)
                {
                    employee.Department = dept;
                }
                repo.AddEntity(employee);
                await repo.Complete();
                OnCreateEmployee(employee);

                emp.DefaultPassword = password;
                emp.EmployeeResponse = map.Map<EmployeeResponse>(employee);
                emp.verificationToken = verificationlink;
                emp.IsSuccess = true;
            }
            else
                emp.FailureMessage = "Email is already in used.";
            return emp;
            
        }
        protected virtual void OnCreateEmployee(Employee employee)
        {
            EmployeeCreated?.Invoke(this, new EmployeeEventArg { Employee=employee});
        }
        
    }
}
