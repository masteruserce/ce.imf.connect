using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define Leads table (container in Cosmos DB)
        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<InsuranceProduct> InsuranceProducts => Set<InsuranceProduct>();
        public DbSet<SourcingDetails> SourcingDetails => Set<SourcingDetails>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<InsuranceProduct>().ToTable("InsuranceProducts");
            modelBuilder.Entity<SourcingDetails>().ToTable("SourcingDetails");
            base.OnModelCreating(modelBuilder);
        }
    }
}
