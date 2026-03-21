using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Models;

namespace OnionArchitecture.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
