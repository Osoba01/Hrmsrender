using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories.IBase;

namespace HRMS.Domain.IRepositories
{
    public interface IProjectRepo:IBaseRepo<CompanyProject>
    {
        Task<List<CompanyProject>> ProjectsByManager(Guid managerId);
    }
}
