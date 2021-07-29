using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Config
{
    public class TestInstanceEntityConfiguration : IEntityTypeConfiguration<TestInstance>
    {
        public void Configure(EntityTypeBuilder<TestInstance> builder)
        {
            builder.HasKey(ti => new {ti.TestId, ti.WorkstationName});

            builder.HasOne(ti => ti.Test)
            .WithMany(t => t.Instances)
            .HasForeignKey(ti => ti.TestId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ti => ti.Group)
            .WithMany(g => g.TestInstances)
            .HasForeignKey(ti => ti.GroupId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(ti => ti.Workstation)
            .WithMany(w => w.TestInstances)
            .HasForeignKey(ti => ti.WorkstationName)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}