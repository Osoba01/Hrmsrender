using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetAllDepartment
{
    public record GetAllDepartmentQuery:IRequest<IEnumerable<DepartmentResponse>>;
}
