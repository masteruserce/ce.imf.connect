using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace e.imf.connect.infra.Config
{
    public class LeadConfig : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Proposer).IsRequired().HasMaxLength(100);
            builder.Property(l => l.ProposerDob).IsRequired();
            builder.Property(l => l.ProposerPan).HasMaxLength(10);
            builder.Property(l => l.ProposerAadhar).HasMaxLength(12);

            builder.Property(l => l.LifeAssured).HasMaxLength(100);
            builder.Property(l => l.LifeAssuredDob).IsRequired();
            builder.Property(l => l.LifeAssuredPan).HasMaxLength(10);
            builder.Property(l => l.LifeAssuredAadhar).HasMaxLength(12);

            builder.Property(l => l.Nominee).HasMaxLength(100);
            builder.Property(l => l.NomineeDob);
            builder.Property(l => l.NomineePan).HasMaxLength(10);
            builder.Property(l => l.NomineeAadhar).HasMaxLength(12);
            builder.Property(l => l.NomineePhone).HasMaxLength(12);

            builder.Property(l => l.Phone).HasMaxLength(15);
            builder.Property(l => l.Email).HasMaxLength(100);
            builder.Property(l => l.Address).HasMaxLength(250);
            builder.Property(l => l.District).HasMaxLength(50);
            builder.Property(l => l.Pincode).HasMaxLength(10);
            builder.Property(l => l.IsActive).HasMaxLength(50);
            builder.Property(l => l.CreatedBy).HasMaxLength(50);
            builder.Property(l => l.CreatedDate).IsRequired();
            builder.Property(l => l.UpdatedBy).HasMaxLength(50);
            builder.Property(l => l.UpdatedDate);
        }
    }
}
