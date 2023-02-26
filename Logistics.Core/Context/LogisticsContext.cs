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
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderState)
                .HasConversion<int>();
        }

        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
