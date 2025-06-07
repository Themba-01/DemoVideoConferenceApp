using System.Security.Cryptography;
using DemoVideoConference.Server.Feature.MeetingFeature.CreateMeeting.Command;
using DemoVideoConference.Server.Models;
using DemoVideoConference.Shared.Meeting.Responses;
using DemoVideoConferenceApp.Server.Infrastructure.Data;
using DemoVideoConferenceApp.Server.Infrastructure.Services;
using MediatR;

namespace DemoVideoConference.Server.Features.MeetingFeature.CreateMeeting.Handler
{
    public class CreateMeetingHandler(AppDbContext context, IConfiguration config, ITwilioService twilioService) : IRequestHandler<CreateMeetingCommand, CreateMeetingResponse>
    {
        public async Task<CreateMeetingResponse> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            if (request.CreateMeeting == null) return new() { IsSuccess = false, Message = "Object sent is NULL"};

            if (DateTimeOffset.Parse(request.CreateMeeting.StartDateOnly) < DateTimeOffset.UtcNow) return new() { IsSuccess = false, Message="Start date cannot be lesser than today's date"};
                
            if (DateTimeOffset.Parse(request.CreateMeeting.EndDateOnly) < DateTimeOffset.Parse(request.CreateMeeting.StartDateOnly)) return new() { IsSuccess = false, Message="Start date cannot be lesser than today's date"};

             string meetingId = GenerateMeetingId();

             TwilioServiceResponse twilioResponse = twilioService.CreateRoom(meetingId);

             if (!twilioResponse.IsSuccess) return new() { IsSuccess = twilioResponse.IsSuccess, Message = twilioResponse.Message };

             var meeting = new Meeting
             {
                MeetingId = meetingId,
                HostId = request.CreateMeeting.HostId,
                Title = request.CreateMeeting.Title,
                Description = request.CreateMeeting.Description,
                StartDateOnly = request.CreateMeeting.StartDateOnly,
                EndDateOnly = request.CreateMeeting.EndDateOnly,
                StartTimeOnly = request.CreateMeeting.StartTimeOnly,
                EndTimeOnly = request.CreateMeeting.EndTimeOnly,
                Passcode = GenerateMeetingPasscode()
             };

             meeting.Link = GenerateLink(meeting.MeetingId, meeting.Passcode);
             context.Meetings.Add(meeting);
             await context.SaveChangesAsync(cancellationToken);

             return new() { IsSuccess = true, Message ="Meeting created"};
        }

        private static string GenerateMeetingId() => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("/", "").Replace("+", "").TrimEnd('=');

        private string GenerateLink(string meetingId, string passcode) => $"{config["Client:BaseAddress"]}/join-meeting/{meetingId}/{passcode}";

        public static string GenerateMeetingPasscode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[4];
            rng.GetBytes(bytes);

            var randomPart = new char[4];
            for (int i=0; i < 4; i++)
                randomPart[i] = chars[bytes[i] % chars.Length];

            string timestamp = DateTime.UtcNow.ToString("HHmmss");
            return $"{new string (randomPart)}{timestamp}";
        }

    }
}