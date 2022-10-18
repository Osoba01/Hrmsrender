using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMSinfrastructure.Data;

namespace HRMSinfrastructure.Repositories.CommandRepo
{
    public class PerformanceRepo : BaseRepo<Performance>, IPerformanceRepo
    {
        
        public PerformanceRepo(HRMSDbContext _context) : base(_context)
        {
           
        }

    }
}
