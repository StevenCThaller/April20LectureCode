using Microsoft.EntityFrameworkCore;

namespace EntityIntro.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<Burrito> Burritos { get; set; }
        public DbSet<RitoMaster> RitoMasters { get; set; }
        public DbSet<Vegetable> Veggies { get; set; }
        public DbSet<VegRito> VegRitos { get; set; }
    }
}