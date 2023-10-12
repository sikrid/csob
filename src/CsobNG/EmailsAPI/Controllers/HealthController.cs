using EmailsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
		EmailService _emailService;

		public HealthController(EmailService emailService)
		{
			_emailService = emailService;
		}

		[HttpGet("")]

        public ActionResult<string> GetStatus()
        {
			if (!_emailService.TryDbConnection())
			{
				return Ok("DB Disconnect");
			}
			else
			{
				return Ok("healthy");
			}
		}
    }
}
