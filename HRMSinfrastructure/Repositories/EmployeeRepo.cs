
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMS.Infrastructure.Repositories.BaseRepo;
using HRMScore.HRMSenums;
using HRMSinfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Infrastructure.Repositories
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
                .Include(x => x.Manager).
                Include(x => x.Department)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Employee>> EmployeeByManager(Guid ManagerId)
        {
            return await context.Employee
                .Where(x => x.Manager.Id == ManagerId)
                .Include(x => x.Manager)
                .Include(x => x.Department)
                .ToListAsync();
        }
    }
}
