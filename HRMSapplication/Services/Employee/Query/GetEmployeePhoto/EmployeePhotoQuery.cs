using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSapplication.Queries.GetEmployeePhoto
{
    public record EmployeePhotoQuery(Guid EmployeeId):IRequest<byte[]?>;
}
