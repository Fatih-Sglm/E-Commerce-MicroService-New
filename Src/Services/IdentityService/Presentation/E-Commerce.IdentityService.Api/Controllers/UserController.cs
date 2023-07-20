using E_Commerce.IdentityService.Application.Features.AppUsers.Command.ResetPassword;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.UpdateUserPassword;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyEmail;
using E_Commerce.IdentityService.Application.Features.AppUsers.Command.VerifyResetPassword;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("VerifyResetPasswordToken")]
        public async Task<IActionResult> VerifyResetPasswordToken(VerifyResetPasswordCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordResetCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
