using DemoVideoConference.Shared.Meeting.Responses;
using MediatR;

namespace DemoVideoConference.Server.Features.MeetingFeature.GetRecentMeetings.Query
{
    public record GetRecentMeetingsQuery(string HostId) : IRequest<GetRecentMeetingsResponse>;
}
