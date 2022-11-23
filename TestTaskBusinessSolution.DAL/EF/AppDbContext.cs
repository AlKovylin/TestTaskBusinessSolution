using Microsoft.EntityFrameworkCore;
using TestTaskBusinessSolution.DAL.Configs;
using TestTaskBusinessSolution.DAL.Entities;

namespace TestTaskBusinessSolution.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Provider>? Providers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ProviderConfiguration());

            modelBuilder.Entity<Provider>().HasData(InitDB.CreateProvider());
            modelBuilder.Entity<Order>().HasData(InitDB.CreateOrder());
            modelBuilder.Entity<Item>().HasData(InitDB.CreateItem());
        }
    }
}
