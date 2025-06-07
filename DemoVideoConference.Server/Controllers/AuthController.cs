using DemoVideoConference.Shared.Authentication.Requests;
using DemoVideoConference.Shared.Authentication.Responses;
using DemoVideoConferenceApp.Server.Features.Authentication.CreateUserAccount.Command;
using DemoVideoConferenceApp.Server.Features.Authentication.LoginUser.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoVideoConference.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(ISender sender) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<CreateUserResponse>> CreateUser(CreateUserRequest user)
        {
            CreateUserResponse Response = await sender.Send(new CreateUserCommand(user));
            return Response.IsSuccess ? Ok(Response) : BadRequest(Response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUserResponse>> LoginUser(LoginUserRequest login)
        {
            LoginUserResponse Response = await sender.Send(new LoginUserCommand(login));
            return Response.IsSuccess ? Ok(Response) : BadRequest(Response);
        }
    }
}