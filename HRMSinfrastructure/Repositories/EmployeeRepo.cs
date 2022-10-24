
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
                .Where(x => x.Manager != null && x.Manager.Id == ManagerId)
                .Include(x => x.Manager)
                .Include(x => x.Department)
                .ToListAsync();
        }

        public async Task<List<Employee>> EmployeeOnLeaveByManager(Guid ManagerId)
        {
           var p= await context.ApplyLeave.
                Where(x => x.StartDate.Date <= DateTime.Today &&
               x.StartDate.AddDays(x.Leave.Days) >= DateTime.Today && 
               x.Employee.Manager !=null &&
               x.Employee.Manager.Id==ManagerId)
                .Include(x => x.Employee)
                .ToListAsync();

            return p.Select(x => x.Employee).ToList();
        }
    }
}
