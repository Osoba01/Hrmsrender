using HRMS.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.WorkExparience.Command.Remove
{
    public record RemoveWorkExparienceCommand(Guid Id):IRequest<bool>;

    internal record RemoveWorkExparienceCommandHandler : IRequestHandler<RemoveWorkExparienceCommand, bool>
    {
        private readonly IWorkExperienceRepo _repo;

        public RemoveWorkExparienceCommandHandler(IWorkExperienceRepo repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(RemoveWorkExparienceCommand request, CancellationToken cancellationToken)
        {
            var exp=await _repo.FindAsync(request.Id);
            if (exp is not null)
            {
                _repo.RemoveEntity(exp);
                return await _repo.Complete() > 0;
            }else
                return false;
        }
    }
}
