using HRMScore.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HRMSapplication.Commands.UploadEmpoyeePhoto
{
    public record UploadEmployeePhotoCommandHandler : IRequestHandler<UploadEmployeePhotoCommand>
    {
        private readonly IEmployeeRepo repo;

        public UploadEmployeePhotoCommandHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Unit> Handle(UploadEmployeePhotoCommand request, CancellationToken cancellationToken)
        {
            var emp= await repo.FindAsync(request.EmployeeId);
            if (emp is not null)
            {
                repo.PatchUpdate(emp);
                emp.Photo = await ImageToByteArray(request.Photo);
                await repo.Complete();
                return Unit.Value;
            }
            else
                throw new ArgumentException("Record not found.");
        }

        private async Task<byte[]> ImageToByteArray(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            return stream.ToArray();
        }
    }
}
