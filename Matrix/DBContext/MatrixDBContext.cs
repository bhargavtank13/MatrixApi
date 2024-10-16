using Matrix.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Matrix.DBContext
{
    public class MatrixDBContext : DbContext
    {
        public MatrixDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RegionalSaleDirector> RegionalSaleDirectors { get; set; }
        public DbSet<Sourcing> Sourcings{ get; set; }
        public DbSet<SalesRep> SalesReps { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<Sales> Sales{ get; set; }
        public DbSet<RepeatItem> RepeatItems { get; set; }
        public DbSet<History> History { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasIndex(c => c.CustomerNumber).IsUnique();
            builder.Entity<Sales>().HasIndex(c => c.QuoteNumber).IsUnique();
        }
    }
}

