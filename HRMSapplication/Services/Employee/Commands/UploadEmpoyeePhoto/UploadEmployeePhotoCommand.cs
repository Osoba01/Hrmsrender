using HRMS.Application.Services.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Commands.UploadEmpoyeePhoto
{
    public record UploadEmployeePhotoCommand(IFormFile Photo,Guid EmployeeId ):IRequest<BaseCommandResponse>;
}
