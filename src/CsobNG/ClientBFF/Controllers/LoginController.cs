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

            var result = await http.GetAsync($"{ClientAPIurl}/Client/ByEmail/{email}");

            if (result.IsSuccessStatusCode)
            {
                var client = result.Content.ReadFromJsonAsync<Client>();
                
                return Ok(client.Result);
            }

            return Ok($"{email} not found - chyba 6371843");
        }
    }
}
