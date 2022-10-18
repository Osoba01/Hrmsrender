using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMSinfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.Infrastructure.Repositories
{
    public class ApplyLeaveRepo : BaseRepo<ApplyLeave>, IApplyLeaveRepo
    {
        private readonly HRMSDbContext context;

        public ApplyLeaveRepo(HRMSDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<IEnumerable<ApplyLeave>> ApplyLeaveByPredicate(Expression<Func<ApplyLeave, bool>> predicate)
        {
            return await context.ApplyLeave
                .Where(predicate)
                .Include(x => x.Employee)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplyLeave>> OnGoingLeave()
        {
            return await context.ApplyLeave.
                Where(x => x.StartDate.Date <= DateTime.Today &&
            x.StartDate.AddDays(x.Leave.Days) >= DateTime.Today)
                .Include(x => x.Employee)
                .Include(x => x.Leave)
                .ToListAsync();
        }
    }
}
