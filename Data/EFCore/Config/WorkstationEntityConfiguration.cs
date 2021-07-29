using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Config
{
    public class WorkstationEntityConfiguration : IEntityTypeConfiguration<Workstation>
    {
        public void Configure(EntityTypeBuilder<Workstation> builder)
        {
            builder.HasKey(w => w.Name);
            builder.HasOne(w => w.Branch)
            .WithMany(b => b.Workstations)
            .HasForeignKey(w => new {w.Bank, w.OU})
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}