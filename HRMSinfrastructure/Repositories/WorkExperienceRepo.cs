using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMSinfrastructure.Data;
using HRMSinfrastructure.Repositories.CommandRepo.BaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.Repositories
{
    public class WorkExperienceRepo:BaseRepo<WorkExperience>,IWorkExperienceRepo
    {
        public WorkExperienceRepo(HRMSDbContext _context):base(_context)
        {

        }
    }
}
