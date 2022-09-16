
using HRMScore.Entities;
using HRMScore.HRMSenums;
using HRMScore.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace HRMSinfrastructure.Repositories.CommandRepo
{
    public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
    {
        private readonly HRMSDbContext context;

        public EmployeeRepo(HRMSDbContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<Employee?> EmployeeById(Guid id)
        {
            return await context.Set<Employee>()
                .Include(x=>x.Manager).
                Include(x=>x.Department)
                 .Include(x => x.EmployeeProjects)
                .Include(x => x.companyProjects)
                .Include(x => x.workExperiences)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Employee>> EmployeeByManager(Guid ManagerId)
        {
            return await context.Employee
                .Where(x => x.Manager.Id == ManagerId)
                .Include(x => x.Manager)
                .Include(x => x.Department)
                .Include(x=>x.EmployeeProjects)
                .Include(x=>x.companyProjects)
                .Include(x=>x.workExperiences)
                .ToListAsync();
        }
    }
}
