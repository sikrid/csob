using Microsoft.EntityFrameworkCore;

namespace EmailsAPI.Data
{
    public class EmailDbContext : DbContext
    {
        public DbSet<Model.Email> Emails { get; set; }

        public EmailDbContext(DbContextOptions<EmailDbContext> options) : base(options)
        {

        }
    }
}
