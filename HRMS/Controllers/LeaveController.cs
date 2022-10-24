using HRMSapplication.Commands.ApplyForLeave;
using HRMSapplication.Commands.ApproveLeave;
using HRMSapplication.Commands.CreateLeave;
using HRMSapplication.Commands.RejectOrCancleLeave;
using HRMSapplication.Commands.UpdateLeave;
using HRMSapplication.Queries.GetAllActiveApplyLeave;
using HRMSapplication.Queries.GetAllLeave;
using HRMSapplication.Queries.GetEmployeeOnLeave;
using MediatR;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AllLeave()
        {
            return Ok(await _mediator.Send(new AllLeaveQuery()));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] CreateLeaveCommand leave)
        {
            return Ok(await _mediator.Send(leave));
        }
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody]UpdateLeaveCommand leave)
        {
            var resp = await _mediator.Send(leave);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForLeave([FromBody] ApplyForLeaveCommand applyLeave)
        {
            var resp = await _mediator.Send(applyLeave);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }
        
        [HttpPatch("Approve")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Approve([FromBody] ApproveLeaveCommand approve)
        {
            var resp = await _mediator.Send(approve);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }
        
        [HttpPatch("cancle")]
        public async Task<IActionResult> Cancle(RejectOrConcleLeaveCommand cancle)
        {
            var resp = await _mediator.Send(cancle);
            if (resp.IsSuccess)
            {
                return Ok();
            }
            else
                return BadRequest(resp.Message);
        }

        [HttpGet("onGoingLeave")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> OnGoingLive()
        {
            return Ok(await _mediator.Send(new EmployeeOnLeaveQuery()));
        }
        [HttpGet("appliedLeave")]
        [Authorize(Roles = "Manager,HR")]
        public async Task<IActionResult> AppliedLeave()
        {
            return Ok(await _mediator.Send(new AllActiveAppyLeaveQuery()));
        }
    }
}
