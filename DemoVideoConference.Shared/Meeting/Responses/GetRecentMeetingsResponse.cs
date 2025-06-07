namespace DemoVideoConference.Shared.Meeting.Responses
{
    public record GetRecentMeetingsResponse : ServiceResponse<IEnumerable<GetMeeting>>;
}