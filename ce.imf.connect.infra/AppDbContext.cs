using ce.imf.connect.models;
using ce.imf.connect.models.InsuranceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for all models
        public DbSet<Customer> Customer => Set<Customer>();
        public DbSet<InsuranceProduct> InsuranceProducts => Set<InsuranceProduct>();
        public DbSet<SourcingDetails> SourcingDetails { get; set; }
        public DbSet<PolicyLoginDetails> PolicyLoginDetails { get; set; }
        public DbSet<PlanPremiumDetails> PlanPremiumDetails { get; set; }
        public DbSet<RevenueDetails> RevenueDetails { get; set; }
        public DbSet<BaseDetails> BaseDetails { get; set; }
        public DbSet<PcDetails> PcDetails { get; set; }
        public DbSet<FiftyBcDetails> FiftyBcDetails { get; set; }
        public DbSet<OtherAmountDetails> OtherAmountDetails { get; set; }
        public DbSet<FinalDetails> FinalDetails { get; set; }
        public DbSet<GstDetails> GstDetails { get; set; }
        public DbSet<TotalDetails> TotalDetails { get; set; }
        public DbSet<PayoutDetails> PayoutDetails { get; set; }
        public DbSet<InsuranceCategory> InsuranceCategories { get; set; }
        public DbSet<FieldConfig> FieldConfigs { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<FormDataValue> FormDataValues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Clients>().ToTable("Clients").HasKey(e=>e.ClientId);
            modelBuilder.Entity<InsuranceProduct>().ToTable("InsuranceProduct");
            modelBuilder.Entity<InsuranceCategory>().ToTable("InsuranceCategory").HasKey(e=>e.CategoryId);
            modelBuilder.Entity<Customer>().ToTable("Customer").HasKey( e=>e.Id);
            modelBuilder.Entity<SourcingDetails>().ToTable("SourcingDetails").HasKey(e => e.Id);
            modelBuilder.Entity<PolicyLoginDetails>().ToTable("PolicyLoginDetails").HasKey(e => e.Id);
            modelBuilder.Entity<PlanPremiumDetails>().ToTable("PlanPremiumDetails").HasKey(e => e.Id);
            modelBuilder.Entity<RevenueDetails>().ToTable("RevenueDetails").HasKey(e => e.Id);
            modelBuilder.Entity<BaseDetails>().ToTable("BaseDetails").HasKey(e => e.Id);
            modelBuilder.Entity<PcDetails>().ToTable("PcDetails").HasKey(e => e.Id);
            modelBuilder.Entity<FiftyBcDetails>().ToTable("FiftyBcDetails").HasKey(e => e.Id);
            modelBuilder.Entity<OtherAmountDetails>().ToTable("OtherAmountDetails").HasKey(e => e.Id);
            modelBuilder.Entity<FinalDetails>().ToTable("FinalDetails").HasKey(e => e.Id);
            modelBuilder.Entity<GstDetails>().ToTable("GstDetails").HasKey(e => e.Id);
            modelBuilder.Entity<TotalDetails>().ToTable("TotalDetails").HasKey(e => e.Id);
            modelBuilder.Entity<PayoutDetails>().ToTable("PayoutDetails").HasKey(e => e.Id);
            
        // Additional configurations can be added here
        //modelBuilder.Entity<InsuranceCategory>(entity =>
        //{
        //    entity.HasKey(e => e.CategoryId);
        //    entity.Property(e => e.CategoryName).IsRequired().HasMaxLength(100);
        //    entity.Property(e => e.Description).HasMaxLength(255);
        //    entity.Property(e => e.IsActive).HasDefaultValue(true);
        //    entity.Property(e => e.CreatdDate).HasDefaultValueSql("GETDATE()");
        //    entity.Property(e => e.CreatedBy).HasDefaultValue("System");
        //});

        modelBuilder.Entity<Customer>()
                .HasOne<SourcingDetails>()
                .WithMany()
                .HasForeignKey(p => p.SourcingDetailsId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Customer>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(p => p.ApplicationNo);
            //// ApplicationNo as Candidate Key for SourcingDetails
            //modelBuilder.Entity<SourcingDetails>()
            //    .HasAlternateKey(s => s.ApplicationNo);

            //// Configure relationships (ApplicationNo + SourcingId FKs)

            //modelBuilder.Entity<PolicyLoginDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(p => p.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PolicyLoginDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(p => p.ApplicationNo);

            //modelBuilder.Entity<PlanPremiumDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(p => p.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PlanPremiumDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(p => p.ApplicationNo);

            //modelBuilder.Entity<RevenueDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(r => r.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<RevenueDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(r => r.ApplicationNo);

            //modelBuilder.Entity<BaseDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(b => b.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<BaseDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(b => b.ApplicationNo);

            //modelBuilder.Entity<PcDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(p => p.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PcDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(p => p.ApplicationNo);

            //modelBuilder.Entity<FiftyBcDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(f => f.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<FiftyBcDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(f => f.ApplicationNo);

            //modelBuilder.Entity<OtherAmountDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(o => o.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<OtherAmountDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(o => o.ApplicationNo);

            //modelBuilder.Entity<FinalDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(f => f.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<FinalDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(f => f.ApplicationNo);

            //modelBuilder.Entity<GstDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(g => g.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<GstDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(g => g.ApplicationNo);

            //modelBuilder.Entity<TotalDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(t => t.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<TotalDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(t => t.ApplicationNo);

            //modelBuilder.Entity<PayoutDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasForeignKey(p => p.SourcingId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PayoutDetails>()
            //    .HasOne<SourcingDetails>()
            //    .WithMany()
            //    .HasPrincipalKey(s => s.ApplicationNo)
            //    .HasForeignKey(p => p.ApplicationNo);
        }
    }
}
