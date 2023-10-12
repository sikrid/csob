
using Model;

namespace ClientAPI.Services
{
    public class ClientService
    {
        private List<Client> Clients { get; set; } = new List<Client>()
        {
            new Client() { Id = 1, FirstName = "Karel", LastName = "Čtrvtý", Email = "karel@ctvrty.cz" },
            new Client() { Id = 2, FirstName = "Jenda", LastName = "Novák", Email = "jenda@novak.cz" }
        };

        public List<Client> GetClients()
        {
            return Clients;
        }

        public void AddClient(Client client)
        {
            int id = Clients.Max(x => x.Id) + 1;
            client.Id = id;
            Clients.Add(client);
        }
    }
}
