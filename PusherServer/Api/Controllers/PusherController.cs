using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PusherController(IPusherService _pusherService) : ControllerBase
    {

        private const string CHANNEL = "twila-pusher-poc";
        public const string EVENTNAME = "twila-event";

        [HttpPost("trigger")]
        public async Task<IActionResult> TriggerEvent([FromBody] Body dto)
        {
            await _pusherService.TriggerEvent(CHANNEL, EVENTNAME, new { dto.Message });
            return Ok(new { message = "Event triggered" });
        }
    }

    public class Body
    {
        public string? Message { get; set; }
    }
}
