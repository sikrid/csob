using ClientAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ClientAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<List<Client>> GetClients()
        {
            var Clients = _clientService.GetClients().ToList();

            return Ok(Clients);
        }

        [Route("ById/{id:int}")]
        [HttpGet]
        public ActionResult<Client> GetClient(int id)
        {
            var Client = _clientService.GetClients().FirstOrDefault(x => x.Id == id);

            return Ok(Client);
        }

        [HttpPost]
        public ActionResult CreateClient(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            _clientService.CreateClient(client);

            return Ok(client.Id);
        }

        [Route("ByEmail/{email}")]
        [HttpGet]
        public ActionResult<Client> GetClient(string email)
        {
            var Client = _clientService.GetClientByEmail(email);

            if (Client == null)
            {
                return NotFound("Klient s tímto emailem není!");
            }

            return Ok(Client);
        }
    }
}
