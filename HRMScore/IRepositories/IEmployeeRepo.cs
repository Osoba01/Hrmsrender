using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories.IBase;
using HRMScore.HRMSenums;

namespace HRMS.Domain.IRepositories
{
    public interface IEmployeeRepo : IBaseRepo<Employee>
    {
        Task<Employee?> EmployeeById(Guid id);
        Task<List<Employee>> EmployeeByManager(Guid ManagerId);
        Task<List<Employee>> EmployeeOnLeaveByManager(Guid ManagerId);
    }
    ///

}
