using HRMS.Application.Utilities;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.AddSkill
{
    public record AddSkillCommand(Guid employId, List<string> SoftSkill, List<string> TechnicalSkill):IRequest;

    public record AddSkillCommandHandler : IRequestHandler<AddSkillCommand>
    {
        private readonly IEmployeeRepo _repo;

        public AddSkillCommandHandler(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public async Task<Unit> Handle(AddSkillCommand request, CancellationToken cancellationToken)
        {
            var emp=await _repo.FindAsync(request.employId);
            if (emp != null)
            {
                _repo.PatchUpdate(emp);
                if (request.SoftSkill.Count > 0)
                {
                    emp.SoftSkill = AddToJsonString(request.SoftSkill, emp.SoftSkill);
                }
                if (request.TechnicalSkill.Count > 0)
                { 
                    emp.TechnicalSkill = AddToJsonString(request.TechnicalSkill, emp.TechnicalSkill);
                }
                await _repo.Complete();
                return Unit.Value;
            } else
                throw new ArgumentException("employee not found.");
        }
        private string? AddToJsonString(List<string> skillList, string? skillString)
        {
            List<string> Skills = new();
            if (skillString != null)
            {
                Skills = skillString.JsonToList();
            }
            Skills.AddRange(skillList);
            return Skills.ListToJason();
        }
    }
}
