using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public class OctopusContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<ApiKey> ApiKeys { get; set; } = null!;
        public DbSet<ApiCall> ApiCalls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HSHM0PP;Initial Catalog=octopus;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[] {
                new Account{UserId=1, Username="admin", Email="admin@email.com", Password="admin", Active=true, CreatedOn=DateTime.Now},
                new Account{UserId=2, Username="user1", Email="user1@email.com", Password="user1", Active=true, CreatedOn=DateTime.Now},
                new Account{UserId=3, Username="user2", Email="user1@email.com", Password="user2", Active=false, CreatedOn=DateTime.Now},
            });

            modelBuilder.Entity<ApiKey>().HasData(new ApiKey[] {
                new ApiKey{Key="1", UserId=1, CreatedOn=DateTime.Now},
                new ApiKey{Key="mCQ6qIqkNy", UserId=2, CreatedOn=DateTime.Now},
            });
        }
    }
}
