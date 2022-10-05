using HRMS.Application.Utilities;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;
using HRMScore.HRMSenums;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.AddSkill
{
    public class SkillCommand
    {

        public string SkillName { get; set; }
        public int Proficiency { get; set; }
        public SkillType SkillType { get; set; }
    }
    public record AddSkillsCommand(Guid EmployeeId, List<SkillCommand> Skills):IRequest<int>;

    public record AddSkillCommandHandler : IRequestHandler<AddSkillsCommand,int>
    {
        private readonly ISkillRepo _repo;
        private readonly IEmployeeRepo _employeeRepo;

        public AddSkillCommandHandler(ISkillRepo repo, IEmployeeRepo employeeRepo)
        {
            _repo = repo;
            
            _employeeRepo = employeeRepo;
        }
        public async Task<int> Handle(AddSkillsCommand request, CancellationToken cancellationToken)
        {
            var employee= await _employeeRepo.FindAsync(request.EmployeeId);
            if (employee is not null)
            {
                _repo.AddRange(await MapSkills(employee, request.Skills));
                return await _repo.Complete();
            }
            else
                throw new ArgumentNullException("employee not found.");
            
        }
        
        private async Task<List<Skill>> MapSkills(HRMScore.Entities.Employee employee, List<SkillCommand> skillCommands)
        {
            List<Skill> skills = new();
            foreach (SkillCommand skCd in skillCommands)
            {
                if (skCd.SkillName is not null)
                {
                var _skill = await _repo.FindByPredicate(x => x.SkillName.ToLower() == skCd.SkillName
                && x.Employee == employee);
                    if (!_skill.Any())
                    {
                        skills.Add(new Skill()
                        {
                            SkillName = skCd.SkillName,
                            SkillType = skCd.SkillType,
                            Proficiency=skCd.Proficiency,
                            Employee = employee,
                        });
                    }
                }
            }
            return skills;
        }
    }
}
