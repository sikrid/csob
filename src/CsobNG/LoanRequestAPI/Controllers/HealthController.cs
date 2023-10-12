using LoanRequestAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanRequestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
		LoanRequestService _loanRequestService;

		public HealthController(LoanRequestService loanRequestService)
		{
			_loanRequestService = loanRequestService;
		}

		[HttpGet("")]

        public ActionResult<string> GetStatus()
        {
			if (!_loanRequestService.TryDbConnection())
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
