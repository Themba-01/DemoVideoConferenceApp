namespace DemoVideoConference.Shared.Meeting.Requests
{
    public record AttachDetailsToConnectionIdRequest(string ConnectionId, string UserId, string Name);

}