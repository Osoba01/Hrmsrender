using HRMSapplication.Commands.CreateDepartment;
using HRMSapplication.Commands.UpdateDate;
using HRMSapplication.Queries.GetAllDepartment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllDepartmentQuery()));
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentCommand newDepartment)
        {
            return Ok(await _mediator.Send(newDepartment));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateDepartmentCommand department)
        {
            var resp = await _mediator.Send(department);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }
    }
}
