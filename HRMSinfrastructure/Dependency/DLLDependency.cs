
using HRMS.Application.Services.AppliedLeave.CommonResponse;
using HRMS.Application.Services.CommonDepartment;
using HRMS.Application.Services.Employee.Common;
using HRMS.Application.Services.EmployeeService.Common;
using HRMS.Application.Services.LeaveService.Common;
using HRMS.Application.Services.ProjectService.Common;
using HRMS.Application.Services.WorkExparienceService.Common;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories;
using HRMS.Infrastructure.Utilities;
using HRMSinfrastructure.Repositories.CommandRepo;
using Microsoft.Extensions.DependencyInjection;
using HRMSapplication.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Commands.ForgotPassword;
using HRMS.Auth;

namespace HRMSinfrastructure.Dependency
{
    public static class DLLDependency
    {
        public static IServiceCollection DependencyCollection(this IServiceCollection services)
        {
           
            services.AddTransient<ISendEmailEvent, CreateEmployeeCommandHandler>();
            services.AddTransient<IResetPasswordEvent,ForgotPasswordCommandHandler>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddTransient<IMapApplyLeave, MapApplyLeave>();
            services.AddTransient<IMapDepartment, MapDepartment>();
            services.AddTransient<IMapEmployee, MapEmployee>();
            services.AddTransient<IMapLeave, MapLeave>();
            services.AddTransient<IMapWorkExperience, MapWorkExperience>();
            services.AddTransient<IMapProject, MapProject>();

            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<ILeaveRepo, LeaveRepo>();
            services.AddScoped<IPerformanceRepo, PerformanceRepo>();
            services.AddScoped<IApplyLeaveRepo, ApplyLeaveRepo>();
            services.AddScoped<IWorkExperienceRepo, WorkExperienceRepo>();
            services.AddScoped<IProjectRepo, ProjectRepo>();
            services.AddScoped<ISkillRepo,SkillRepo>();
            services.AddScoped<IEmployeeProjectRepo, EmployerProjectRepo>();
      
            return services;
        }
    }
}
