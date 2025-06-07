using DemoVideoConference.Shared.Meeting.Responses;
using MediatR;

namespace DemoVideoConference.Server.Features.MeetingFeature.GetMeetings
{
    public record GetMeetingsQuery(string HostId) : IRequest<GetMeetingsResponse>;
}