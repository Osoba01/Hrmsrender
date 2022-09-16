using HRMSapplication.Commands.CreateLeave;
using HRMSapplication.Response;
using HRMScore.Entities;

namespace HRMS.Application.Services.LeaveService.Common
{
    public interface IMapLeave
    {
        Leave CreateCommandToEntity(CreateLeaveCommand command);
        IEnumerable<LeaveResponse> EntityToResponse(IEnumerable<Leave> entities);
        LeaveResponse EntityToResponse(Leave entity);
    }
}