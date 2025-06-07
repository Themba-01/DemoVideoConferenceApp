using DemoVideoConference.Server.Features.MeetingFeature.GetRecentMeetings.Query;
using DemoVideoConference.Shared.Meeting.Responses;
using DemoVideoConferenceApp.Server.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoVideoConference.Server.Features.MeetingFeature.GetRecentMeetings.Handler
{
    public class GetRecentMeetingsHandler(AppDbContext context) : IRequestHandler<GetRecentMeetingsQuery, GetRecentMeetingsResponse>
    {
        public async Task<GetRecentMeetingsResponse> Handle( GetRecentMeetingsQuery request, CancellationToken cancellationToken )
        {
            var meetings = await context.Meetings.AsNoTracking().Where(_ => _.HostId == request.HostId && _.IsCompleted ).ToListAsync(cancellationToken: cancellationToken);

            if ( meetings.Count == 0 ) return new()
            {
                IsSuccess = false,
                Message = "No recent meetings found"
            };

            var recentMeetings = meetings.Select(x => new GetMeeting
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
                Data = recentMeetings,
                IsSuccess = true,
                Message = $"{recentMeetings.Count} recent meetings found"
            };
        }
    }
}
