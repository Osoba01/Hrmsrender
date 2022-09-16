using HRMS.Application.Services.EmployeeProject.Command.CreateEmployeeProject;
using HRMS.Application.Services.EmployeeProject.Command.UpdateEmployee;
using HRMS.Application.Services.EmployeeProject.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> PersonalProject([FromBody] CreateEmployeeProjectCommand PersonalProject)
        {
            return Ok(await _mediator.Send(PersonalProject));   
        }
        [HttpPut]
        public async Task<IActionResult> PersonalProject([FromBody] UpdateEmployeeProjectCommand PersonalProject)
        {
            return Ok(await _mediator.Send(PersonalProject));
        }
        [HttpGet]
        public async Task<IActionResult> PersonalProject(Guid employeeId)
        {
            return Ok(await _mediator.Send(new EmployeeProjectQuery(employeeId)));
        }
    }
}
