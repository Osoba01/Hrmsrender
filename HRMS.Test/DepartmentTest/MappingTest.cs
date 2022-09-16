using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HRMSapplication.Commands.CreateDepartment;
using AutoMapper;
using HRMSapplication.ProfileMapping;
using HRMScore.IRepositories;
using HRMSinfrastructure.Repositories.CommandRepo;
using HRMSinfrastructure.Data;
using HRMS.Application.Services.CommonDepartment;
using static HRMS.Test.DommmyData;
using HRMS.Application.Services.EmployeeService.Common;
using static HRMS.Application.Utilities.Logic;

namespace HRMS.Test.Department
{
    public class MappingTest
    {
        private readonly IMapper mapper;
        public MappingTest()
        {
            var myProfile = new HRMSMProfile();
            var conFig = new MapperConfiguration(x => x.AddProfile(myProfile));
            mapper = new Mapper(conFig);
        }
        [Fact]
        public void MapCreateCommandToDepartment_MustWork()
        {
            CreateDepartmentCommand dp = new("Softwere", "Develop all kind of software");
            MapDepartment map = new(mapper);
            var actual = map.CreateCommandToEntity(dp);
            Assert.NotNull(actual);
            Assert.True(actual.Name == dp.Name && actual.Description == dp.Description);
        }
        [Fact]
        public void MapDepartmentToResponse_MustWork()
        {
            MapDepartment map = new(mapper);
            var actual = map.EntityToResponse(dept2);
            Assert.NotNull(actual);
            Assert.True(actual.Name == dept2.Name && actual.Description == dept2.Description && actual.Id.ToString() == dept2.Id.ToString() && $"{dept2.HOD.FirstName} {dept2.HOD.Surname} {dept2.HOD.OtherName}" == actual.HOD);
        }


        [Fact]
        public void MapDepartToResponseList_MustWork()
        {
            MapDepartment map = new(mapper);
            var actual = map.EntityToResponse(Departments()).ToList();
            Assert.NotNull(actual);
            Assert.True(actual.Count() == 3);
            Assert.True(actual[1].HOD == $"{dept2.HOD.FirstName} {dept2.HOD.Surname} {dept2.HOD.OtherName}");
        }
        [Fact]
        public void MapEmployeeToResponse_MustWork()
        {
            MapEmployee map = new(mapper);
            var actual = map.EntityToResponse(employee3);
            Assert.NotNull(actual);
            Assert.True(actual.Manager== $"{employee2.FirstName} {employee2.Surname} {employee2.OtherName}");
            Assert.Equal(dept2.Name,actual.DepartmentName);
        }
        [Fact]
        public void MapEmployeeListToResponse_MustWork()
        {
            MapEmployee map = new(mapper);
            var actual = map.EntityToResponse(Employees()).ToList();
            Assert.NotNull(actual);
            Assert.True(actual.Count() == 5);
            Assert.Equal(actual[2].Manager, $"{employee2.FirstName} {employee2.Surname} {employee2.OtherName}");
            Assert.Equal(dept2.Name, actual[2].DepartmentName);
        }
        [Fact]
        public void JsonSerializeList_MustWork()
        {
            var actual = StringList.ListToJason();
            Assert.True(actual != null);
            Assert.True(actual.Length>10);
        }
    }
}
