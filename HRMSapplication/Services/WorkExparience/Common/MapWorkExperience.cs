using AutoMapper;
using HRMS.Application.Services.WorkExparience.Command.CreateWorkExperience;
using HRMS.Application.Services.WorkExparience.CommonResponse;
using HRMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.WorkExparienceService.Common
{
    public class MapWorkExperience : IMapWorkExperience
    {
        private readonly IMapper _map;

        public MapWorkExperience(IMapper map)
        {
            _map = map;
        }
        public ExperienceResponse EntityToResponse(WorkExperience entity)
        {
            return _map.Map<ExperienceResponse>(entity);
        }
        public IEnumerable<ExperienceResponse> EntityToResponse(IEnumerable<WorkExperience> entities)
        {
            return _map.Map<IEnumerable<ExperienceResponse>>(entities);
        }
        public WorkExperience CreateCommandToEntity(AddWorkExperienceCommand command)
        {
            return _map.Map<WorkExperience>(command);
        }
    }
}
