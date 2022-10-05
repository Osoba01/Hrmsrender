﻿using AutoMapper;
using HRMS.Application.Services.ProjectService.Common;
using HRMS.Domain.IRepositories;
using HRMScore.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Project.Command.CreateProject
{
    public record CreateProjectCommand(Guid ProjectManagerId,string Name, List<Guid> teamMemberIds):IRequest;


    public record CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IProjectRepo _repo;
        private readonly IMapProject _map;
        private readonly IEmployeeRepo _empRepo;

        public CreateProjectCommandHandler(IProjectRepo repo, IMapProject map, IEmployeeRepo empRepo)
        {
            _repo = repo;
            _map = map;
            _empRepo = empRepo;
        }
        public async Task<Unit> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var proj = _map.CreateCommandToEntity(request);
            var teamLead= await _empRepo.FindAsync(request.ProjectManagerId);
            if (teamLead is not null)
            {
                proj.Manager = teamLead;
                proj.Team.Add(teamLead);
                foreach (var memberId in request.teamMemberIds)
                {
                    var member = await _empRepo.FindAsync(memberId);
                    if (member is not null)
                    {
                        proj.Team.Add(member);
                    }
                }
                _repo.AddEntity(proj);
                await _repo.Complete();
                return Unit.Value;
            }
            else
                throw new NullReferenceException("Manager not found.");
        }
    }
}
