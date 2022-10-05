using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplyLeave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPprove = table.Column<bool>(type: "bit", nullable: false),
                    IsReject = table.Column<bool>(type: "bit", nullable: false),
                    ApproverMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplyLeave_Leave_LeaveId",
                        column: x => x.LeaveId,
                        principalTable: "Leave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CompanyProjectEmployee",
                columns: table => new
                {
                    CompanyProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProjectEmployee", x => new { x.CompanyProjectsId, x.TeamId });
                });

            migrationBuilder.CreateTable(
                name: "CompanyProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectStatus = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HODId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OtherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    MaritalInfo = table.Column<int>(type: "int", nullable: false),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEmployed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StaffId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKingFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKingSurName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKingPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextOfKingEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<int>(type: "int", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JobRole = table.Column<int>(type: "int", nullable: true),
                    JobLocation = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkType = table.Column<int>(type: "int", nullable: true),
                    ContractType = table.Column<int>(type: "int", nullable: true),
                    ConfirmedStatus = table.Column<bool>(type: "bit", nullable: false),
                    RecievedOfferLetter = table.Column<bool>(type: "bit", nullable: false),
                    LastDatePromoted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    NTry = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonthlyRating = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performances_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillType = table.Column<int>(type: "int", nullable: false),
                    Proficiency = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplyLeave_EmployeeId",
                table: "ApplyLeave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplyLeave_LeaveId",
                table: "ApplyLeave",
                column: "LeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProjectEmployee_TeamId",
                table: "CompanyProjectEmployee",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProjects_ManagerId",
                table: "CompanyProjects",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_HODId",
                table: "Department",
                column: "HODId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId",
                table: "EmployeeProjects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_EmployeeId",
                table: "Performances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_EmployeeId",
                table: "Skill",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_EmployeeId",
                table: "WorkExperiences",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplyLeave_Employee_EmployeeId",
                table: "ApplyLeave",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProjectEmployee_CompanyProjects_CompanyProjectsId",
                table: "CompanyProjectEmployee",
                column: "CompanyProjectsId",
                principalTable: "CompanyProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProjectEmployee_Employee_TeamId",
                table: "CompanyProjectEmployee",
                column: "TeamId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProjects_Employee_ManagerId",
                table: "CompanyProjects",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_HODId",
                table: "Department",
                column: "HODId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_HODId",
                table: "Department");

            migrationBuilder.DropTable(
                name: "ApplyLeave");

            migrationBuilder.DropTable(
                name: "CompanyProjectEmployee");

            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.DropTable(
                name: "CompanyProjects");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
