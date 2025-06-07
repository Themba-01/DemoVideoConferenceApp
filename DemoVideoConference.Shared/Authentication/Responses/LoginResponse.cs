namespace DemoVideoConference.Shared.Authentication.Responses
{
    public record LoginUserResponse(string JwtToken) : ServiceResponse<string>;
}