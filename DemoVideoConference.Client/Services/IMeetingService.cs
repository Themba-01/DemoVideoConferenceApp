using System.Net.Http.Json;
using DemoVideoConference.Shared.Meeting.Requests;
using DemoVideoConference.Shared.Meeting.Responses;
using DemoVideoConferenceApp.Client.Extensions;

namespace DemoVideoConference.Client.Services
{
    public interface IMeetingService
    {
        Task<CreateMeetingResponse?> CreateMeeting(CreateMeetingRequest meeting);
        Task<GetMeetingsResponse?> GetMeetings(string hostId);
        Task<GetRecentMeetingsResponse?> GetRecentMeetings(string hostId);
    }

    public class MeetingService(IHttpExtension httpExtension) : IMeetingService
    {
        public async Task<CreateMeetingResponse?> CreateMeeting(CreateMeetingRequest meeting)
        {
        try
        {
            var result = await (await httpExtension.GetPrivateClient()).PostAsJsonAsync("meeting/create", meeting);
            return await result.Content.ReadFromJsonAsync<CreateMeetingResponse>();
        }
        catch
        {
            return new CreateMeetingResponse { IsSuccess = false, Message = "Error connecting to server!"};
        }
        }

        public async Task<GetMeetingsResponse?> GetMeetings(string hostId)
        {
        try
        {
            var result = await (await httpExtension.GetPrivateClient()).GetAsync($"meeting/{hostId}");
            return await result.Content.ReadFromJsonAsync<GetMeetingsResponse>();
        }
        catch
        {
            return new GetMeetingsResponse {IsSuccess = false, Message = "Error connecting to server"};
        }
        }
        public async Task<GetRecentMeetingsResponse?> GetRecentMeetings(string hostId)
        {
            try
            {
                var result = await(await httpExtension.GetPrivateClient()).GetAsync($"meeting/recent/{hostId}");
                return await result.Content.ReadFromJsonAsync<GetRecentMeetingsResponse>();
            }

            catch
            {
                return new GetRecentMeetingsResponse { IsSuccess = false, Message = "Error connecting to server"};
            }
            
        }
    }
}