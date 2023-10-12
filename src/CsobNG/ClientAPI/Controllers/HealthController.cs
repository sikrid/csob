using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
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
