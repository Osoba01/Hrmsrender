using AutoMapper;
using HRMS.Application.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMS.Auth;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSapplication.Response;
using MediatR;
using System.Security.Cryptography;

namespace HRMSapplication.Commands.CreateEmployee
{
    public record CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>, ISendEmailEvent
    {
        private readonly IEmployeeRepo repo;
        private readonly IMapper map;
        private readonly IAuthService _authService;
        private readonly IDepartmentRepo _departmentRepo;

        public CreateEmployeeCommandHandler(IEmployeeRepo repo, IMapper map, IAuthService authService, IDepartmentRepo departmentRepo)
        {
            this.repo = repo;
            this.map = map;
            _authService = authService;
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
                string verificationlink = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                string password = _authService.GetRandomPassword(9);
                _authService.EncryptPassword(password, employee);
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
