using DemoVideoConference.Shared.Meeting.Responses;
using DemoVideoConferenceApp.Server.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoVideoConference.Server.Features.MeetingFeature.GetMeetings.Handler
{
    public class GetMeetingsHandler(AppDbContext context) : IRequestHandler<GetMeetingsQuery, GetMeetingsResponse>
    {
        // get all meetings scheduled by specific hosts
        public async Task<GetMeetingsResponse> Handle(GetMeetingsQuery request, CancellationToken cancellationToken)
        {
            var meetings = await context.Meetings.AsNoTracking().Where(_=>_.HostId == request.HostId && _.IsCompleted == false).ToListAsync(cancellationToken: cancellationToken);

            if (meetings.Count == 0) return new()
            {
                IsSuccess = false,
                Message = "No meeting found"
            };

            //populate and return
            var _meetings = meetings.Select(x => new GetMeeting
        {
            HostId = request.HostId,
            Title = x.Title,
            Description = x.Description,
            StartTimeOnly = x.StartTimeOnly,
            EndTimeOnly = x.EndTimeOnly,
            StartDateOnly = x.StartDateOnly,
            EndDateOnly = x.EndDateOnly,
            Id = x.Id.ToString(),
            Passcode = x.Passcode,
            MeetingId = x.MeetingId,
            Link = x.Link
        }).ToList();

        return new()
        {
            Data = _meetings,
            IsSuccess = true,
            Message = $"{_meetings.Count} meetings found"
        };
        }

        
        
    }
}
