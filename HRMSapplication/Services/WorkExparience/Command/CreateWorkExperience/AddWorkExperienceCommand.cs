using AutoMapper;
using HRMS.Application.Services.Common;
using HRMS.Application.Services.WorkExparienceService.Common;
using HRMS.Domain.IRepositories;
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
          DateTime StartDate , DateTime EndDate , Guid employeeId,
          string Location
        ):IRequest<BaseCommandResponse>;

    public record AddWorkExperienceCommandHandler : IRequestHandler<AddWorkExperienceCommand, BaseCommandResponse>
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
        public async Task<BaseCommandResponse> Handle(AddWorkExperienceCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp= (await _empRep.FindByPredicate(x=>x.Id==request.employeeId)).FirstOrDefault();
            if (emp is not null)
            {
                var p = _map.CreateCommandToEntity(request);
                p.Employee = emp;
                _repo.AddEntity(p);
                await _repo.Complete();
                response.IsSuccess = true;
            }
            else
                response.Message = "User not found." ;
            return response;
        }
    }
}
