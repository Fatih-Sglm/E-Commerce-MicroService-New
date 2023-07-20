using E_Commerce.IdentityService.Application.Features.AppUsers.Command.CreateUser;
using E_Commerce.IdentityService.Application.Features.Auth.Command.Login.RefreshTokenLogin;
using E_Commerce.IdentityService.Application.Features.Auth.Command.Login.User;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginUserCommand login)
        {
            return Ok(await _mediator.Send(login));
        }

        [HttpPost("RefreshTokenLogin")]
        public async Task<IActionResult> RefreshTokenLoginAsync(RefreshTokenLoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
