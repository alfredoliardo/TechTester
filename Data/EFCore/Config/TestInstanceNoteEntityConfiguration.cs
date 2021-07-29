using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Config
{
    public class TestInstanceNoteEntityConfiguration : IEntityTypeConfiguration<TestInstanceNote>
    {
        public void Configure(EntityTypeBuilder<TestInstanceNote> builder)
        {
            builder.HasKey(n => new {n.TestId, n.WorkstationName, n.CreationTime});
            builder.HasOne(n => n.TestInstance)
            .WithMany(ti => ti.Notes)
            .HasForeignKey(n => new {n.TestId, n.WorkstationName})
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(n => n.Text).IsRequired();
        }
    }
}