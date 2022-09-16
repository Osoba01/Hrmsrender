using AutoMapper;
using HRMS.Application.Services.WorkExparienceService.Common;
using HRMS.Domain.IRepositories;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.WorkExparience.Command.CreateWorkExperience
{
    public record AddWorkExperienceCommand(
         string body ,string JobRole , string Department,
   DateTime StartDate , DateTime EndDate , Guid employeeId
        ):IRequest;

    public record AddWorkExperienceCommandHandler : IRequestHandler<AddWorkExperienceCommand>
    {
        private readonly IWorkExperienceRepo _repo;
        private readonly IMapWorkExperience _map;
        private readonly IEmployeeRepo _empRep;

        public AddWorkExperienceCommandHandler(IWorkExperienceRepo repo, IMapWorkExperience map,IEmployeeRepo empRep)
        {
            _repo = repo;
            _map = map;
            _empRep = empRep;
        }
        public async Task<Unit> Handle(AddWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            var emp= (await _empRep.FindByPredicate(x=>x.Id==request.employeeId)).FirstOrDefault();
            if (emp is not null)
            {
                var p = _map.CreateCommandToEntity(request);
                p.Employee = emp;
                _repo.AddEntity(p);
                await _repo.Complete();
                return Unit.Value;
            }
            else
                throw new ArgumentException("User not found.");
        }
    }
}
