using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMSinfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories
{
    public class ProjectRepo:BaseRepo<CompanyProject>, IProjectRepo
    {
        private readonly HRMSDbContext context;

        public ProjectRepo(HRMSDbContext _context):base(_context)
        {
            context = _context;
        }

        public async Task<List<CompanyProject>> ProjectsByManager(Guid managerId)
        {
            return await context.CompanyProjects
                .Where(x => x.Manager.Id == managerId)
                .Include(x => x.Team)
                .ToListAsync();
        }
    }
}
