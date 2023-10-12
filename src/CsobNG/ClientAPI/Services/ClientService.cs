﻿
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

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
    }
}