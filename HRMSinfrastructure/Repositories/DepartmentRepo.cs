using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMSinfrastructure.Data;

namespace HRMS.Infrastructure.Repositories
{
    public class DepartmentRepo : BaseRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(HRMSDbContext _context) : base(_context)
        {

        }

    }
}
