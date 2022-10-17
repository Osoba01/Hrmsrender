using HRMS.Application.Services.Project.Command.CreateProject;
using HRMS.Application.Services.Project.Command.UpdateProjet;
using HRMS.Application.Services.Project.Query.GetAllProject;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles = "Admin , Manager")]
        public async Task<IActionResult> CompanyProject([FromBody] CreateProjectCommand Project)
        {
            var resp = await _mediator.Send(Project);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }
        [HttpPut]
        public async Task<IActionResult> CompanyProject([FromBody] UpdatePropjetCommand Project)
        {
            return Ok(await _mediator.Send(Project));
        }
        [HttpGet("byManager")]
        public async Task<IActionResult> CompanyProjectByManager(Guid id)
        {
            return Ok(await _mediator.Send(new ProjectMyManagerQuery(id)));
        }
    }
}
