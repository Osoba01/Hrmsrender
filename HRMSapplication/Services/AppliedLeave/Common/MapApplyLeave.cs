using AutoMapper;
using HRMS.Domain.Entities;
using HRMSapplication.Commands.ApplyForLeave;
using HRMSapplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.AppliedLeave.CommonResponse
{
    public class MapApplyLeave: IMapApplyLeave
    {
        private readonly IMapper _map;

        public MapApplyLeave(IMapper map)
        {
            _map = map;
        }
        public ApplyLeaveResponse EntityToResponse(ApplyLeave entity)
        {
            return _map.Map<ApplyLeaveResponse>(entity);
        }
        public IEnumerable<ApplyLeaveResponse> EntityToResponse(IEnumerable<ApplyLeave> entities)
        {
            return _map.Map<IEnumerable<ApplyLeaveResponse>>(entities);
        }
        public ApplyLeave CreateCommandToEntity(ApplyForLeaveCommand command)
        {
            return _map.Map<ApplyLeave>(command);
        }
    }
    
}
