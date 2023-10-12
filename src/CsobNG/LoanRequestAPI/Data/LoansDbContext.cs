using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Model;
using System.Reflection.Metadata;

namespace LoanRequestAPI.Data
{
    public class LoansDbContext : DbContext
    {
        public DbSet<LoanRequest> LoanRequests { get; set; }
        
        public LoansDbContext(DbContextOptions<LoansDbContext> options) : base(options)
        {
            
        }

        
    }
}
