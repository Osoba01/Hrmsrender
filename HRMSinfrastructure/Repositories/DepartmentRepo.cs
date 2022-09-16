using HRMScore.Entities;
using HRMScore.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;

namespace HRMSinfrastructure.Repositories.CommandRepo
{
    public class DepartmentRepo : BaseRepo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(HRMSDbContext _context) : base(_context)
        {
    
        }
       
    }
}
