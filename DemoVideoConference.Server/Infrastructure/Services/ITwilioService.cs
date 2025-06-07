using DemoVideoConference.Shared.Meeting.Responses;
using Twilio;
using Twilio.Jwt.AccessToken;
using Twilio.Rest.Video.V1;

namespace DemoVideoConferenceApp.Server.Infrastructure.Services
{
    public interface ITwilioService
    {
        TwilioServiceResponse GenerateMeetingToken(string identity, string meetingId);
        TwilioServiceResponse CreateRoom(string roomName);
    }

    public class TwilioService : ITwilioService
    {
        private readonly string _accountSid;
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly string _authToken;
        
        public TwilioService(IConfiguration configuration)
        {
            _accountSid = configuration["Twilio:AccountSid"]!;
            _apiKey = configuration["Twilio:ApiKey"]!;
            _apiSecret = configuration["Twilio:ApiSecret"]!;
            _authToken = configuration["Twilio:AuthToken"]!;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public TwilioServiceResponse CreateRoom(string roomName)
        {
            var response = RoomResource.Create(
                type: RoomResource.RoomTypeEnum.Group,
                uniqueName: roomName,
                maxParticipants: 10,
                recordParticipantsOnConnect: false);
            if (response.Sid != null) return new() {IsSuccess = true, Message = $"response.Status"};
            else return new() {IsSuccess = false, Message = $"Room could not be created"};
        }

        public TwilioServiceResponse GenerateMeetingToken(string identity, string meetingId)
        {
            var grants = new HashSet<IGrant> {new VideoGrant {Room =  meetingId}};
            var token = new Token(_accountSid, _apiKey, _apiSecret, identity, grants: grants);
            return new() 
            {
                IsSuccess = true, 
                Message ="Token generated successfully", 
                Data = token.ToJwt()
            };
        }
    }
}
