using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Test> Tests {get;set;}
        public DbSet<Check> Checks {get;set;}
        public DbSet<Workstation> Workstations {get;set;}
        public DbSet<TestCheck> TestChecks {get;set;}
        public DbSet<TestInstance> TestInstances {get;set;}
        public DbSet<TestCheckResponse> TestCheckResponses {get;set;}
        public DbSet<Group> Groups {get;set;}
        public DbSet<TestInstanceNote> TestInstanceNotes {get;set;}
        public DbSet<Branch> Branches {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}