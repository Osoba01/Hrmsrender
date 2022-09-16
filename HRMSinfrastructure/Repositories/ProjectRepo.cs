using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;

namespace HRMS.Infrastructure.Repositories
{
    public class ProjectRepo:BaseRepo<CompanyProject>, IProjectRepo
    {
        public ProjectRepo(HRMSDbContext _context):base(_context)
        {

        }
    }
}
