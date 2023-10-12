using ClientAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ClientDbContext context;

        public SeedController(ClientDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{count:int}")]
        public string Generate(int count)
        {
            try
            {
                var clients = Faker.FakeClients.GetClients(count);
                context.Clients.AddRange(clients);
                context.SaveChanges();
                return "ok";
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
