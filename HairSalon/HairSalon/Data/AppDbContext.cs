using HairSalon.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
