using HRMS.API.Files.manager;
using HRMS.Application.Queries.GetEmployeeById;
using HRMS.Application.Services.Employee.Commands.AddSkill;
using HRMS.Application.Services.Employee.Commands.CreateEmployee;
using HRMS.Application.Services.Employee.Common;
using HRMS.Application.Services.Employee.Query.GetSkill;
using HRMS.Application.Services.Employee.Query.HrInfo;
using HRMSapplication.Commands.CreateEmployee;
using HRMSapplication.Commands.RemoveEmployee;
using HRMSapplication.Commands.UpdateEmployee;
using HRMSapplication.Commands.UpdateEmployeeDepartment;
using HRMSapplication.Commands.UploadEmpoyeePhoto;
using HRMSapplication.Queries.GetAllEmployees;
using HRMSapplication.Queries.GetEmployeeByDepartment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        readonly string certificateBaseUrl = "Files\\certificate";
        private readonly IMediator _mediator;
        private readonly IFileManager _file;
        private readonly ISendEmailEvent _createEmployeeEvent;
        private readonly IEmailService _emailService;

        public EmployeeController(IMediator mediator, IFileManager file, ISendEmailEvent createEmployeeEvent,IEmailService emailService)
        {
            _mediator = mediator;
            _file = file;
            _createEmployeeEvent = createEmployeeEvent;
            _emailService = emailService;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand employee)
        {
            _createEmployeeEvent.EmployeeCreated += _emailService.OnCreateEmployee;
            var empResp=await _mediator.Send(employee);
            if (empResp.IsSuccess)
            {
                _createEmployeeEvent.EmployeeCreated-= _emailService.OnCreateEmployee;
                return Ok(empResp);
            }else
                return BadRequest(empResp.FailureMessage);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("updateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateEmployeeRoleCommand updateEmployeeRole)
        {
            return Ok(await _mediator.Send(updateEmployeeRole));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand updateEmployee)
        {
            return Ok(await _mediator.Send(updateEmployee));
        }
        [HttpGet]
        [Authorize(Roles = "Admin, HR")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new AllEmployeeQuery()));
        }

        [HttpGet("hrInfo")]
        [Authorize(Roles = "HR")]
        public async Task<IActionResult> GetHrInfo()
        {
            return Ok(await _mediator.Send(new HrInfoCommand()));
        }
        [HttpGet("byManager")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetByManager(Guid managerId)
        {
            return Ok(await _mediator.Send(new EmployeeByManagerQuery(managerId)));
        }
        [HttpGet("byId")]
        public async Task<IActionResult> GetEmployeeId(Guid id)
        {
            return Ok(await _mediator.Send(new EmployeeByIdCommand(id)));
        }
        [HttpGet("skill")]
        public async Task<IActionResult> GetSkill(Guid EmployeeId)
        {
            return Ok(await _mediator.Send(new SkillQuery(EmployeeId)));
        }
        [HttpPatch("addSkill")]
        public async Task<IActionResult> AddSkill(AddSkillsCommand skills)
        {
            return Ok(await _mediator.Send(skills));
        }

        [HttpPost("uploadPhoto")]
        public async Task<IActionResult> UploadPhoto(IFormFile file,Guid EmployeeId)
        {
            return Ok(await _mediator.Send (new UploadEmployeePhotoCommand(file, EmployeeId)));
        }

        [HttpPost("uploadCertificate")]
        public async Task<IActionResult> uploadCertificate(IFormFile file, Guid id, string certificateName)
        {
            var isSave = await _file.SaveFile(file, $"{certificateBaseUrl}\\{id}", certificateName);
            if (isSave)
                return Ok();
            else
                return BadRequest("Unsuccessfull");
        }

        [HttpGet("download-Certificate")]
        public FileContentResult DownloadFile(string certificateName, Guid id)
        {
            string folderPath = $"{certificateBaseUrl}\\{id}\\{certificateName}";
            return File(System.IO.File.ReadAllBytes(folderPath), "application/octet-stream", certificateName);
        }

        [HttpGet("employee-Certificates")]
        public List<string> EmployeeCertificate(Guid id)
        {
            var fullPth = Path.Join(Directory.GetCurrentDirectory(), $"{certificateBaseUrl}\\{id}");
            DirectoryInfo directInfo = new DirectoryInfo(fullPth);
            List<FileInfo> files= directInfo.GetFiles("*.*").ToList();
            List<string> fileNames = new();
            files.ForEach(x=>fileNames.Add(x.Name));
            return fileNames;
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new RemoveEmployeeCommand(id)));
        }
        
        
    }
}
