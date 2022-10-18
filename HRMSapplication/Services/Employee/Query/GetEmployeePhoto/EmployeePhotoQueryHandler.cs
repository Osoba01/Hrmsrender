using HRMS.Domain.IRepositories;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeePhoto
{
    public record EmployeePhotoQueryHandler : IRequestHandler<EmployeePhotoQuery, byte[]?>
    {
        private readonly IEmployeeRepo repo;

        public EmployeePhotoQueryHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<byte[]?> Handle(EmployeePhotoQuery request, CancellationToken cancellationToken)
        {
            var emp = await repo.FindAsync(request.EmployeeId);
            if (emp is not null)
                return emp.Photo;
            return null;
        }
    }
}
