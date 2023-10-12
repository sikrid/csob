using Microsoft.EntityFrameworkCore;
using Model;

namespace ClientAPI.Data
{
    public class ClientDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options)
        {
        }

    }
}