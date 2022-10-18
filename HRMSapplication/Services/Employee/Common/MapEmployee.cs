using AutoMapper;
using HRMSapplication.Commands.UpdateEmployee;
using HRMSapplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.EmployeeService.Common
{
    public class MapEmployee : IMapEmployee
    {
        private readonly IMapper _map;

        public MapEmployee(IMapper map)
        {
            _map = map;
        }
        public EmployeeResponse EntityToResponse(Domain.Entities.Employee entity)
        {
            return _map.Map<EmployeeResponse>(entity);
        }
        public IEnumerable<EmployeeResponse> EntityToResponse(IEnumerable<Domain.Entities.Employee> entities)
        {
            return _map.Map<IEnumerable<EmployeeResponse>>(entities);
        }
        //public HRMScore.Entities.Employee UpdateCommandToEntity(UpdateEmployeeCommand command)
        //{
        //    return _map.Map<HRMScore.Entities.Employee>(command);
        //}
    }
}
