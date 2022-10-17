using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using HRMScore.HRMSenums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.EmployeeProject.Command.UpdateEmployee
{
    public record UpdateEmployeeProjectCommand(Guid Id, string Name, string? Link, ProjectState Status, string description): IRequest<BaseCommandResponse>;

    public record UpdateEmployeeProjectCommandHandler : IRequestHandler<UpdateEmployeeProjectCommand, BaseCommandResponse>
    {
        private readonly IEmployeeProjectRepo _repo;

        public UpdateEmployeeProjectCommandHandler(IEmployeeProjectRepo repo)
        {
            _repo = repo;
        }

        public async Task<BaseCommandResponse> Handle(UpdateEmployeeProjectCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var employeeProject = await _repo.FindAsync(request.Id);
            if (employeeProject is not null)
            {
                _repo.PatchUpdate(employeeProject);
                employeeProject.Name = request.Name;
                employeeProject.Link = request.Link;
                employeeProject.Status = request.Status;
                employeeProject.Description = request.description;
                await _repo.Complete();
                response.IsSuccess = true;
            }
            else
                response.Message="Project not found.";
            return response;
        }
    }

}
