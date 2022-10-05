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
    public class SkillRepo : BaseRepo<Skill>, ISkillRepo
    {
        public SkillRepo(HRMSDbContext _context) : base(_context)
        {
        }
    }
}
