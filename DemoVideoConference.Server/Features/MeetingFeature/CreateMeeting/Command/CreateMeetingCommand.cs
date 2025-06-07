using DemoVideoConference.Shared.Meeting.Requests;
using DemoVideoConference.Shared.Meeting.Responses;

using MediatR;

namespace DemoVideoConference.Server.Feature.MeetingFeature.CreateMeeting.Command
{
    public record CreateMeetingCommand(CreateMeetingRequest CreateMeeting) : IRequest<CreateMeetingResponse>;
    
}