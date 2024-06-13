using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Database.EnsureCreated();
        }

        private readonly IConfiguration _configuration;

        #region Tables (DbSets)

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServerConnectionString"));
        }
    }
}
