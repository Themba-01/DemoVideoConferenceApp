using DemoVideoConference.Shared.Authentication.Requests;
using DemoVideoConference.Shared.Authentication.Responses;
using MediatR;

namespace DemoVideoConferenceApp.Server.Features.Authentication.CreateUserAccount.Command
{
    public record CreateUserCommand(CreateUserRequest User) : IRequest<CreateUserResponse>
    {}
}