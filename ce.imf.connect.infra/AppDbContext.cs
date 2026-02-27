using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;

namespace ce.imf.connect.infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for all models
        public DbSet<FieldConfig> FieldConfigs { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Section> sections { get; set; }
        public DbSet<FormDataValue> FormDataValues { get; set; }
        public DbSet<ClientUser> Users { get; set; }
        public DbSet<UserMenu> UserMenus { get; set; }
        public DbSet<PostalCode> PostalCode { get; set; }
        public DbSet<AutoInsuranceFormDataValues> AutoInsuranceFormDataValues { get; set; }
        public DbSet<LifeInsuranceFormDataValues> LifeInsuranceFormDataValues { get; set; }
        public DbSet<CropInsuranceFormDataValues> CropInsuranceFormDataValues { get; set; }
        public DbSet<CommercialInsuranceFormDataValues> CommercialInsuranceFormDataValues { get; set; }
        public DbSet<MarineInsuranceFormDataValues> MarineInsuranceFormDataValues { get; set; }
        public DbSet<HealthInsuranceFormDataValues> HealthInsuranceFormDataValues { get; set; }
        public DbSet<PropertyInsuranceFormDataValues> PropertyInsuranceFormDataValues { get; set; }
        public DbSet<TravelInsuranceFormDataValues> TravelInsuranceFormDataValues { get; set; }

        public DbSet<WorkflowTemplate> WorkflowTemplates { get; set; }
        public DbSet<WorkflowState> WorkflowStates { get; set; }
        public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }
        public DbSet<WorkflowTransitionRole> WorkflowTransitionRoles { get; set; }
        public DbSet<WorkflowInstance> WorkflowInstances { get; set; }
        public DbSet<WorkflowHistory> WorkflowHistories { get; set; }
        public DbSet<WorkflowEventTrigger> WorkflowEventTriggers { get; set; }
        public DbSet<FieldStateConfiguration> FieldStateConfigurations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Clients>().ToTable("Clients").HasKey(e=>e.ClientId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientUser>().ToTable("ClientUser").HasKey(e => e.UserId);

            modelBuilder.Entity<WorkflowTemplate>()
            .HasIndex(x => new { x.FormId, x.Version })
            .IsUnique();

            modelBuilder.Entity<WorkflowState>()
                .HasOne(x => x.Template)
                .WithMany(x => x.States)
                .HasForeignKey(x => x.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkflowTransition>()
                .HasOne(x => x.Template)
                .WithMany(x => x.Transitions)
                .HasForeignKey(x => x.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkflowTransition>()
                .HasOne(x => x.FromState)
                .WithMany(x => x.FromTransitions)
                .HasForeignKey(x => x.FromStateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowTransition>()
                .HasOne(x => x.ToState)
                .WithMany(x => x.ToTransitions)
                .HasForeignKey(x => x.ToStateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkflowInstance>()
                .HasIndex(x => x.TransactionId);

            modelBuilder.Entity<WorkflowInstance>()
                .HasIndex(x => x.CurrentStateId);
        }
    }
}
