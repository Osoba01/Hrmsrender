using HRMS.Application.Services.WorkExparience.Command.CreateWorkExperience;
using HRMS.Application.Services.WorkExparience.CommonResponse;
using HRMS.Domain.Entities;

namespace HRMS.Application.Services.WorkExparienceService.Common
{
    public interface IMapWorkExperience
    {
        WorkExperience CreateCommandToEntity(AddWorkExperienceCommand command);
        IEnumerable<ExperienceResponse> EntityToResponse(IEnumerable<WorkExperience> entities);
        ExperienceResponse EntityToResponse(WorkExperience entity);
    }
}