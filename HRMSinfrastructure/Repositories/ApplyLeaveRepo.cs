using HRMScore.Entities;
using HRMScore.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMSinfrastructure.Repositories.CommandRepo
{
    public class ApplyLeaveRepo:BaseRepo<ApplyLeave>,IApplyLeaveRepo
    {
        private readonly HRMSDbContext context;

        public ApplyLeaveRepo(HRMSDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<IEnumerable<ApplyLeave>> ApplyLeaveByPredicate(Expression<Func<ApplyLeave, bool>> predicate)
        {
            return await context.ApplyLeave
                .Where(predicate)
                .Include(x=>x.Employee)
                .ToListAsync();
        }
    }
}
