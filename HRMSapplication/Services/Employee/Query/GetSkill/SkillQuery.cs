using HRMS.Application.Utilities;
using HRMS.Domain.Entities;
using HRMS.Domain.IRepositories;

using MediatR;


namespace HRMS.Application.Services.Employee.Query.GetSkill
{
    public record SkillQuery(Guid employeeId):IRequest<List<Skill>>;

    public record SkillQueryHandler : IRequestHandler<SkillQuery, List<Skill>>
    {
        private readonly ISkillRepo _repo;

        public SkillQueryHandler(ISkillRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<Skill>> Handle(SkillQuery request, CancellationToken cancellationToken)
        {
            
            return (await _repo.FindByPredicate(x=>x.Employee.Id==request.employeeId)).ToList();
        }
    }
}
