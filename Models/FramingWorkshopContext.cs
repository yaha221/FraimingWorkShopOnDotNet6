using Microsoft.EntityFrameworkCore;

namespace FramingWorkshop.Models
{
    /// <summary> Контекст данных приложения Framing Worckshop </summary>
    internal class FramingWorkshopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlite("Data Source=FramingWorkshopDB.db;Initial Catalog=FramingWorkShop/Data;Mode=ReadWrite");
        }
        internal DbSet<Frame> Frames { get; set; } = null!;
        internal DbSet<Cardboard> Cardboards { get; set; }
        internal DbSet<Hanger> Hangers { get; set; }
        internal DbSet<Periphery> Peripheries { get; set; }

    }
}
