using Microsoft.AspNetCore.Mvc;

namespace LoanRequestAPI.Controllers
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
