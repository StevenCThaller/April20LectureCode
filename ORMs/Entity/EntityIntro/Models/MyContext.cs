using Microsoft.EntityFrameworkCore;

namespace EntityIntro.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<Burrito> Burritos { get; set; }
        public DbSet<RitoMaster> RitoMasters { get; set; }
    }
}