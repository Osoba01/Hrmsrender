using HRMS.Application.Utilities;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Query.GetSkill
{
    public record SkillQuery(Guid employeeId):IRequest<SkillResponse>;

    public record SkillQueryHandler : IRequestHandler<SkillQuery, SkillResponse>
    {
        private readonly IEmployeeRepo _repo;

        public SkillQueryHandler(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public async Task<SkillResponse> Handle(SkillQuery request, CancellationToken cancellationToken)
        {
            var emp = await _repo.FindAsync(request.employeeId);
            if (emp != null)
            {
                SkillResponse skill = new();
                skill.SoftSkill = emp.SoftSkill.JsonToList();
                skill.Technical = emp.TechnicalSkill.JsonToList();
                return skill;
            }
            else
                throw new ArgumentException("Employee not found.");
        }
    }
}
