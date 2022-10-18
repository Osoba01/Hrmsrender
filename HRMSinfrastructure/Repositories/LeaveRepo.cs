using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMSinfrastructure.Data;

namespace HRMS.Infrastructure.Repositories
{
    public class LeaveRepo : BaseRepo<Leave>, ILeaveRepo
    {
        public LeaveRepo(HRMSDbContext _context) : base(_context)
        {

        }

    }
}
