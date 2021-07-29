using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Config
{
    public class TestCheckEntityConfiguration : IEntityTypeConfiguration<TestCheck>
    {
        public void Configure(EntityTypeBuilder<TestCheck> builder)
        {
            builder.HasKey(tc => new {tc.TestId, tc.CheckId});
            builder.HasOne(tc => tc.Test)
            .WithMany(t => t.TestChecks)
            .HasForeignKey(tc => tc.TestId)
            .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}