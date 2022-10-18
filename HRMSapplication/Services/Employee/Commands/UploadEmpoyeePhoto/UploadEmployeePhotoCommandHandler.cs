using HRMS.Application.Services.Common;
using HRMS.Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HRMSapplication.Commands.UploadEmpoyeePhoto
{
    public record UploadEmployeePhotoCommandHandler : IRequestHandler<UploadEmployeePhotoCommand, BaseCommandResponse>
    {
        private readonly IEmployeeRepo repo;

        public UploadEmployeePhotoCommandHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<BaseCommandResponse> Handle(UploadEmployeePhotoCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new();
            var emp= await repo.FindAsync(request.EmployeeId);
            if (emp is not null)
            {
                repo.PatchUpdate(emp);
                emp.Photo = await ImageToByteArray(request.Photo);
                await repo.Complete();
                response.IsSuccess = true;
            }
            else
                response.Message = "Employee not found.";
            return response;
            
        }

        private async Task<byte[]> ImageToByteArray(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            return stream.ToArray();
        }
    }
}
