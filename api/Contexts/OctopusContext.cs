using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public class OctopusContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HSHM0PP;Initial Catalog=octopus;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[] {
                new Account{UserId=1, Username="admin", Email="admin@email.com", Password="admin", ApiKey="1"},
                new Account{UserId=2, Username="user1", Email="user1@email.com", Password="user1", ApiKey="2"},
            });
        }
    }
}
