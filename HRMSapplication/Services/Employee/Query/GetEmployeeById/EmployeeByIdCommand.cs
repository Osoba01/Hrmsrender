using AutoMapper;
using HRMS.Application.Services.EmployeeService.Common;
using HRMSapplication.Response;
using HRMScore.IRepositories;
using MediatR;

namespace HRMS.Application.Queries.GetEmployeeById
{
    public record EmployeeByIdCommand(Guid Id):IRequest<EmployeeResponse>;

    public record EmployeeByIdCommandHandler : IRequestHandler<EmployeeByIdCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepo _repo;
        private readonly IMapEmployee _map;

        public EmployeeByIdCommandHandler(IEmployeeRepo repo, IMapEmployee map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task<EmployeeResponse> Handle(EmployeeByIdCommand request, CancellationToken cancellationToken)
        {
            var emp = await _repo.EmployeeById(request.Id);
            if (emp != null)
            {
                return _map.EntityToResponse(emp);
            }
            else
                throw new ArgumentException("record with the given Id is not found");
            
        }
    }
}
