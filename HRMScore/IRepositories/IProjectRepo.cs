﻿using HRMS.Domain.Entities;
using HRMScore.IRepositories.ICommandRepo.IBase;

namespace HRMS.Domain.IRepositories
{
    public interface IProjectRepo:IBaseRepo<CompanyProject>
    {
        Task<List<CompanyProject>> ProjectsByManager(Guid managerId);
    }
}
