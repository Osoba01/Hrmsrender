using HRMScore.Entities;
using HRMScore.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;

namespace HRMSinfrastructure.Repositories.CommandRepo
{
    public class PerformanceRepo : BaseRepo<Performance>, IPerformanceRepo
    {
        
        public PerformanceRepo(HRMSDbContext _context) : base(_context)
        {
           
        }

    }
}
