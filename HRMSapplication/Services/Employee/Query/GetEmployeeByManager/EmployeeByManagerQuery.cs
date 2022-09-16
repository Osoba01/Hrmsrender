using HRMSapplication.Response;
using MediatR;

namespace HRMSapplication.Queries.GetEmployeeByDepartment
{
    public record EmployeeByManagerQuery(Guid ManagerId):IRequest<IEnumerable<EmployeeResponse>>;
}
