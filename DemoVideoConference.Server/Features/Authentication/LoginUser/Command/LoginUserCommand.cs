using DemoVideoConference.Shared.Authentication.Requests;
using DemoVideoConference.Shared.Authentication.Responses;
using MediatR;

namespace DemoVideoConferenceApp.Server.Features.Authentication.LoginUser.Command
{
    public record LoginUserCommand(LoginUserRequest Login) : IRequest<LoginUserResponse>;

}
