using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EFCore.Config
{
    public class TestCheckResponseEntityConfiguration : IEntityTypeConfiguration<TestCheckResponse>
    {
        public void Configure(EntityTypeBuilder<TestCheckResponse> builder)
        {
            builder.HasKey(r => new {r.TestId, r.WorkstationName, r.CheckId});
            builder.HasOne(r => r.TestInstance)
            .WithMany(ti => ti.Responses)
            .HasForeignKey(r => new {r.TestId, r.WorkstationName})
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(r => r.TestCheck)
            .WithMany(tc => tc.Responses)
            .HasForeignKey(r => new {r.TestId, r.CheckId})
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}