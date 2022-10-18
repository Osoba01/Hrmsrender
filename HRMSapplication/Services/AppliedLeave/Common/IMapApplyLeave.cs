using HRMS.Domain.Entities;
using HRMSapplication.Commands.ApplyForLeave;
using HRMSapplication.Response;

namespace HRMS.Application.Services.AppliedLeave.CommonResponse
{
    public interface IMapApplyLeave
    {
        ApplyLeaveResponse EntityToResponse(ApplyLeave entity);
        ApplyLeave CreateCommandToEntity(ApplyForLeaveCommand command);
        IEnumerable<ApplyLeaveResponse> EntityToResponse(IEnumerable<ApplyLeave> entities);
    }
    
}
