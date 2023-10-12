
using ClientAPI.Data;
using Model;

namespace ClientAPI.Services
{
    public class ClientService
    {
        ClientDbContext _context;

        public ClientService(ClientDbContext context)
        {
            _context = context;
        }

        public List<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public void CreateClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public Client GetClientByEmail(string email)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
            if (client == null)
            {
                return null;
            }

            return client;
        }
    }
}
