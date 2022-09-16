using HRMS.Domain.Entities;
using HRMS.Infrastructure.EntityConfigurations;
using HRMScore.Entities;
using HRMScore.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSinfrastructure.Data
{
    public class HRMSDbContext : DbContext
    {
        public HRMSDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplyLeave> ApplyLeave { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<CompanyProject> CompanyProjects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            base.OnModelCreating(modelBuilder); 
        }

    }
   

}
