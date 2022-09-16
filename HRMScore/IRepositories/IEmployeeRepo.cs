using HRMScore.Entities;
using HRMScore.HRMSenums;
using HRMScore.IRepositories.ICommandRepo.IBase;

namespace HRMScore.IRepositories
{
    public interface IEmployeeRepo:IBaseRepo<Employee>
    {
        Task<Employee?> EmployeeById(Guid id);
        Task<List<Employee>> EmployeeByManager(Guid ManagerId);
    }
    ///
   
}
