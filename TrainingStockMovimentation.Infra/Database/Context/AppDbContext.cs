using Microsoft.EntityFrameworkCore;
using TrainingStockMovimentation.Domain.Entitys;

namespace TrainingStockMovimentation.Infra.Database.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<StockMovement> StockMovement { get; set; }

        public DbSet<ContaBC> ContaBC { get; set; }

        public DbSet<StockMovementView> StockMovementViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
