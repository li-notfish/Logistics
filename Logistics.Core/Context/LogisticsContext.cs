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
            modelBuilder.Entity<Goods>()
                .HasOne(o => o.Order)
                .WithOne(g => g.Goods)
                .HasForeignKey<Goods>(g => g.OrderId);
            modelBuilder.Entity<Goods>()
                .Property(g => g.GoodsState)
                .HasConversion<int>();
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
            modelBuilder.Entity<Goods>()
                .HasOne<Warehouse>(w => w.Warehouse)
                .WithMany(g => g.Goods)
                .HasForeignKey(fk => fk.WarehouseId)
                .IsRequired(false);
        }

        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Goods> Goodes { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
