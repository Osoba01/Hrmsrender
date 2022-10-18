using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMSinfrastructure.Data;

namespace HRMS.Infrastructure.Repositories
{
    public class EmployerProjectRepo: BaseRepo<EmployeeProject>, IEmployeeProjectRepo
    {
        public EmployerProjectRepo(HRMSDbContext _context):base(_context)
        {
        }
    }
}
