using Microsoft.AspNetCore.Mvc;

namespace ClientBFF.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("")]

        public ActionResult<string> GetStatus()
        {
            return Ok("healthy");
        }
    }
}
