using System.Net.Http.Json;
using DemoVideoConference.Shared.Meeting.Responses;
using DemoVideoConferenceApp.Client.Extensions;
using Microsoft.JSInterop;

namespace DemoVideoConference.Client.Services
{
    public interface ITwilioService
    {
        Task<TwilioServiceResponse?> GenerateMeetingToken(string username, string meetingId);
        Task JoinMeeting(string token, string roomName, string containerId);
    }

    public class TwilioService(IJSRuntime _js, IHttpExtension httpExtension) : ITwilioService
    {
        public async Task<TwilioServiceResponse?> GenerateMeetingToken(string username, string meetingId)
        {
            var result = await httpExtension.GetPublicClient().GetAsync($"twilio/token/{username}/{meetingId}");
            return await result.Content.ReadFromJsonAsync<TwilioServiceResponse>();
        }
        public async Task JoinMeeting(string token, string roomName, string containerId) =>
            await _js.InvokeVoidAsync("window.twilioVideo.connectToRoom", token, roomName, containerId);
    }
}