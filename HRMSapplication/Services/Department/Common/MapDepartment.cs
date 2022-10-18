using AutoMapper;
using HRMS.Domain.Entities;
using HRMSapplication.Commands.CreateDepartment;
using HRMSapplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.Services.CommonDepartment
{
    public class MapDepartment : IMapDepartment
    {
        private readonly IMapper _map;
        public MapDepartment(IMapper map)
        {
            _map = map;
        }
        public DepartmentResponse EntityToResponse(Department entity)
        {
            return _map.Map<DepartmentResponse>(entity);
        }
        public IEnumerable<DepartmentResponse> EntityToResponse(IEnumerable<Department> entities)
        {
            return _map.Map<IEnumerable<DepartmentResponse>>(entities);
        }
        public Department CreateCommandToEntity(CreateDepartmentCommand command)
        {
            return _map.Map<Department>(command);
        }
    }


}
