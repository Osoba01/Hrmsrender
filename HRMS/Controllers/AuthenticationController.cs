using HRMS.Application.Queries.AuthenticateRefreshToken;
using HRMS.Application.Services.Employee.Commands.ForgotPassword;
using HRMS.Application.Services.Employee.Commands.RecoverPassword;
using HRMS.Application.Services.Employee.Common;
using HRMS.Application.Services.Security.VerifyAccount;
using HRMSapplication.Commands.ChangePassword;
using HRMSapplication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IResetPasswordEvent _resetPasswordEvent;
        private readonly IEmailService _emailService;

        public AuthenticationController(IMediator mediator, IResetPasswordEvent resetPasswordEvent, IEmailService emailService)
        {
            _mediator = mediator;
            _resetPasswordEvent = resetPasswordEvent;
            _emailService = emailService;
        }
        [AllowAnonymous]
        [HttpPatch("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand login)
        {
            var loginResponse = await _mediator.Send(login);
            if (loginResponse.IsAuthenticated)
            {
                Response.Cookies.Append("RefreshToken", loginResponse.NewRefreshToken!, new CookieOptions { HttpOnly = true });
                return Ok(loginResponse.AccessToken);
            }
            else
                return BadRequest(loginResponse.FailMessage);
        }

        [HttpPatch("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand changeP)
        {
            var IsSucess = await _mediator.Send(changeP);
            if (IsSucess)
            {
                return Ok();
            }
            else
                return BadRequest("Old password is not correct.");
        }
        [AllowAnonymous]
        [HttpGet("refreshToken")]
        public async Task<IActionResult> GetRefreshToken()
        {
            var HttpRefreshToken = Request.Cookies["RefreshToken"];

            if (HttpRefreshToken != null)
            {
                var RefreshTokenResp = await _mediator.Send(new AuthenticateRefreshTokenQuery(HttpRefreshToken));
                if (RefreshTokenResp.IsAuthenticate)
                {
                    return Ok(RefreshTokenResp.AccessToken);
                }
                else
                    return BadRequest("Invalid token.");
            }
            else
                return Unauthorized();
        }
        [AllowAnonymous]
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            _resetPasswordEvent.ResetPassword += _emailService.OnResetPassword;
            var result = await _mediator.Send(new ForgotPasswordCommand(email));
            _resetPasswordEvent.ResetPassword -= _emailService.OnResetPassword;
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetCommand)
        {
            return Ok(await _mediator.Send(resetCommand));
        }
        [AllowAnonymous]
        [HttpPost("verify-account")]
        public async Task<IActionResult> RerifyAccount([FromBody] VerifyAccountCommand verifyCommand)
        {
            return Ok(await _mediator.Send(verifyCommand));
        }
    }
}
