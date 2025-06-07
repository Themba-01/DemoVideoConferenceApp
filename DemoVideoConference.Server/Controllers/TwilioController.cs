using DemoVideoConference.Shared.Meeting.Responses;
using DemoVideoConferenceApp.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoVideoConference.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwilioController(ITwilioService twilioService) : ControllerBase
    {
        [HttpGet("token/{username}/{meetingId}")]
        [AllowAnonymous]
        public ActionResult<TwilioServiceResponse> GetMeetingToken(string username, string meetingId)
        {
            TwilioServiceResponse response = twilioService.GenerateMeetingToken(username, meetingId);
            return response.IsSuccess ? Ok(Response) : BadRequest(response);
        }
    }
}
