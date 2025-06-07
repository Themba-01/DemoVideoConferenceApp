using DemoVideoConference.Server.Feature.MeetingFeature.CreateMeeting.Command;
using DemoVideoConference.Server.Features.MeetingFeature.GetMeetings;
using DemoVideoConference.Server.Features.MeetingFeature.GetRecentMeetings.Query;
using DemoVideoConference.Shared.Authentication.Requests;
using DemoVideoConference.Shared.Authentication.Responses;
using DemoVideoConference.Shared.Meeting.Requests;
using DemoVideoConference.Shared.Meeting.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DemoVideoConference.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingController(ISender sender) : ControllerBase
    {
        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult<CreateMeetingResponse>> CreateMeeting(CreateMeetingRequest meeting)
        {
            CreateMeetingResponse Response = await sender.Send(new CreateMeetingCommand(meeting));
            return Response.IsSuccess ? Ok(Response) : BadRequest(Response);
        }

        [HttpGet("{hostId}")]
        [Authorize]
        public async Task<ActionResult<GetMeetingsResponse>> GetMeetings(string hostId)
        {
            GetMeetingsResponse Response = await sender.Send(new GetMeetingsQuery(hostId));
            return Response.IsSuccess ? Ok(Response) : NotFound(Response);
        }

        [HttpGet("recent/{hostId}")]
        [Authorize]
        public async Task<ActionResult<GetRecentMeetingsResponse>> GetRecentMeetings(string hostId)
        {
            GetRecentMeetingsResponse Response = await sender.Send(new GetRecentMeetingsQuery(hostId));
            return Response.IsSuccess ? Ok(Response) : NotFound(Response);
        }
    }
}