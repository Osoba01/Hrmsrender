using AutoMapper;
using HRMS.Domain.Entities;
using HRMSapplication.Commands.CreateLeave;
using HRMSapplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.LeaveService.Common
{
    public class MapLeave : IMapLeave
    {
        private readonly IMapper _map;

        public MapLeave(IMapper map)
        {
            _map = map;
        }
        public LeaveResponse EntityToResponse(Leave entity)
        {
            return _map.Map<LeaveResponse>(entity);
        }
        public IEnumerable<LeaveResponse> EntityToResponse(IEnumerable<Leave> entities)
        {
            return _map.Map<IEnumerable<LeaveResponse>>(entities);
        }
        public Leave CreateCommandToEntity(CreateLeaveCommand command)
        {
            return _map.Map<Leave>(command);
        }
    }
}
