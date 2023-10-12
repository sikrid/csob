using Microsoft.AspNetCore.Mvc;
using Model;
using System.Net.Http;
using System;

namespace ClientBFF.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly private string ClientAPIurl = "http://localhost:5208";

        [Route("{email}")]
        [HttpGet]
        public async Task <ActionResult<Client>> GetClientByEmail(string email)
        {
            HttpClient http = new HttpClient();

            var client = await http.GetFromJsonAsync<Client>($"{ClientAPIurl}/ByEmail/{email}");

            if (client == null)
            {
                return NotFound(email);
            }
            else
            {
                return Ok(client);
            }
        }
    }
}
