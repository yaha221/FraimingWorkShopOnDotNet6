using Microsoft.EntityFrameworkCore;

namespace FraimingWorkShop.Models
{
    /// <summary> Контекст данных приложения Framing Worckshop </summary>
    public class FraimingWorkShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Data Source=FramingWorkshopDB.db;Mode=ReadWrite");
        }
        public DbSet<Frame> Frames { get; set; } = null!;
        public DbSet<Cardboard> Cardboards { get; set; }
        public DbSet<Hanger> Hangers { get; set; }
        public DbSet<Periphery> Peripheries { get; set; }

    }
}
