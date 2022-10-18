using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using HRMScore.HRMSenums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.Employee.Commands.UpdateManager
{
    public record UpdateMangerCommand(Guid EmployeeId,Guid ManagerId):IRequest<BaseCommandResponse>;

    internal record UpdateMangerCommandHandler : IRequestHandler<UpdateMangerCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo _repo;

        public UpdateMangerCommandHandler(IEmployeeRepo repo)
        {
            _repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(UpdateMangerCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var empy = await _repo.FindAsync(request.EmployeeId);
            if (empy != null)
            {
                var manager = (await _repo.FindByPredicate(x => x.Id == request.ManagerId)).FirstOrDefault();
                if (manager != null)
                {
                    if (manager.Role == Role.Manager)
                    {
                        _repo.PatchUpdate(empy);
                        empy.Manager = manager;
                        await _repo.Complete();
                        response.IsSuccess = true;
                    }
                    else
                        response.Message = "The employee you selected as a manager is not a manager.";
                } else
                    response.Message = "Manager not found.";
            } else
                response.Message = "Employee not found";
            return response;
        }
    }
}
