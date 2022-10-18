using AutoMapper;
using HRMS.Domain.IRepositories;
using HRMScore.HRMSenums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Project.Command.UpdateProjet
{
    public record UpdatePropjetCommand(Guid Id, ProjectState ProjectStatus, List<Guid> teamMemberIds) :IRequest;

    public record UpdatePropjetCommandHandler : IRequestHandler<UpdatePropjetCommand>
    {
        private readonly IProjectRepo _repo;
        private readonly IEmployeeRepo _empRepo;

        public UpdatePropjetCommandHandler(IProjectRepo repo, IEmployeeRepo empRepo)
        {
            _repo = repo;
            _empRepo = empRepo;
        }
        public async Task<Unit> Handle(UpdatePropjetCommand request, CancellationToken cancellationToken)
        {
            var p = await _repo.FindAsync(request.Id);
            if (p is not null)
            {
                foreach (var memberId in request.teamMemberIds)
                {
                    var member = await _empRepo.FindAsync(memberId);
                    if (member is not null)
                    {
                        p.Team.Add(member);
                    }
                }
                p.ProjectStatus=request.ProjectStatus;
                _repo.Update(p);
                await _repo.Complete();
            }
            return Unit.Value;
        }
    }
}
