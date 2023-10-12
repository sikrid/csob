using ClientAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
		DbService _dbService;

		public HealthController(DbService dbService)
		{
			_dbService = dbService;
		}

		[HttpGet("")]
        
        public ActionResult<string> GetStatus()
        {
			if (!_dbService.TryDbConnection())
			{
                return Ok("DB Disconnect");
			}
            else
            {
                return Ok("helathy");
            }
        }
    }
}
