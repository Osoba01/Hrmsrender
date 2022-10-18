using HRMS.Application.Services.WorkExparience.Command.CreateWorkExperience;
using HRMS.Application.Services.WorkExparience.Command.Remove;
using HRMS.Application.Services.WorkExparience.Query.GetWorkExperienceByEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkExperienceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddWorkExperienceCommand WorkExperience)
        {
            var resp = await _mediator.Send(WorkExperience);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }
        [HttpGet]
        public async Task<IActionResult> Get(Guid employeeId)
        {
            var query=new WorkExperienceByEmployeeQuery(employeeId);
            return Ok(await _mediator.Send(query));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok(await _mediator.Send(new RemoveWorkExparienceCommand(id)));
        }
    }
}
