using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;

namespace HRMS.Infrastructure.Repositories
{
    public class EmployerProjectRepo: BaseRepo<EmployeeProject>, IEmployeeProjectRepo
    {
        public EmployerProjectRepo(HRMSDbContext _context):base(_context)
        {
        }
    }
}
