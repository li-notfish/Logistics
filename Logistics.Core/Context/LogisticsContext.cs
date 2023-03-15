using Logistics.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Logistics.Core.Context
{
    public class LogisticsContext : DbContext
    {
        public LogisticsContext(DbContextOptions<LogisticsContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Delivery>()
                .Property(x => x.State)
                .HasConversion<int>();
            modelBuilder.Entity<Order>()
                .HasOne(d => d.Delivery)
                .WithMany(ds => ds.Orders)
                .HasForeignKey(o => o.DeliveryId)
                .IsRequired(false);
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderState)
                .HasConversion<int>();
            modelBuilder.Entity<WareHouseGoods>().
                HasKey(wg => new {wg.GoodsId,wg.WarehouseId});
            modelBuilder.Entity<WareHouseGoods>()
                .HasOne(wg => wg.Warehouse).WithMany(w => w.Goods).HasForeignKey(wg => wg.WarehouseId);
            modelBuilder.Entity<WareHouseGoods>().HasOne(wg => wg.Goods).WithMany(g => g.Warehouses).HasForeignKey(wg => wg.GoodsId);
        }

        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Goods> Goodes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WareHouseGoods> WareHouseGoods { get; set; }
    }
}
