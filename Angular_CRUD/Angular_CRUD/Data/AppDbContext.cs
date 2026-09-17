using Angular_CRUD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Angular_CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>opt) : base(opt) { }

        public DbSet<User> Users { get; set; }
    }
}
