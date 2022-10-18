using AutoMapper;
using HRMS.Application.Services.EmployeeProject.Query;
using HRMS.Application.Services.Project.Command.CreateProject;
using HRMS.Application.Services.Project.CommonResponse;
using HRMS.Application.Services.WorkExparience.Command.CreateWorkExperience;
using HRMS.Application.Services.WorkExparience.CommonResponse;
using HRMS.Application.Utilities;
using HRMS.Domain.Entities;
using HRMSapplication.Commands.ApplyForLeave;
using HRMSapplication.Commands.CreateDepartment;
using HRMSapplication.Commands.CreateEmployee;
using HRMSapplication.Commands.CreateLeave;
using HRMSapplication.Commands.RateEmployeePerformance;
using HRMSapplication.Commands.UpdateEmployee;
using HRMSapplication.Response;

namespace HRMSapplication.ProfileMapping
{
    public class HRMSMProfile : Profile
    {
        public HRMSMProfile()
        {
            CreateMap<Employee, EmployeeResponse>().
                ForMember(d => d.DepartmentName, opt => opt.MapFrom(src => src.Department!=null? src.Department.Name:null))
               .ForMember(d => d.Manager, opt => opt.MapFrom(src => src.Manager == null ? null : src.Manager.EmployeeName()));

                
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<UpdateEmployeeCommand, Employee>();
               

            CreateMap<ApplyLeave, ApplyLeaveResponse>()
                .ForMember(dest=>dest.EndDate, opt=>opt.MapFrom(src=>src.StartDate.AddDays(src.Leave.Days)))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src =>src.Employee.EmployeeName()))
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.Employee.StaffId));
            CreateMap<ApplyForLeaveCommand, ApplyLeave>();

            
            CreateMap<Department, DepartmentResponse>()
                .ForMember(dest => dest.CountEmployee, opt => opt.MapFrom(src => src.Employees.Count()))
                .ForMember(dest => dest.HOD, opt => opt.MapFrom(src => src.HOD == null?null: src.HOD.EmployeeName()));
            CreateMap<CreateDepartmentCommand,Department>();

            CreateMap<Leave, LeaveResponse>();
            CreateMap<CreateLeaveCommand, Leave>();

            CreateMap<CompanyProject, ProjectResponse>();
            CreateMap<CreateProjectCommand, CompanyProject>();

            CreateMap<WorkExperience, ExperienceResponse>()
                .ForMember(dest=>dest.employeeName,opt=>opt.MapFrom(src=>src.Employee.EmployeeName()));

            CreateMap<AddWorkExperienceCommand, WorkExperience>();

            CreateMap<Performance, PerformanceResponse>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.EmployeeName()))
                .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.Employee.StaffId));
            CreateMap<RateEmployeePerformanceCommand, Performance>();

            CreateMap<EmployeeProject, EmployeeProjectResponse>();
        }
    }
}
