using HRMScore.Entities;
using HRMScore.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;

namespace HRMSinfrastructure.Repositories.CommandRepo
{
    public class LeaveRepo : BaseRepo<Leave>, ILeaveRepo
    {
        public LeaveRepo(HRMSDbContext _context) : base(_context)
        {

        }
      
    }
}
