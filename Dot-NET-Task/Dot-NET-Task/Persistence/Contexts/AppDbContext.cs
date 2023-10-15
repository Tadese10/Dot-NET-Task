
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using DotNETTask.Domains.Models;

namespace DotNETTask.Persistence.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
        { 
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
           this.Database.EnsureCreated();
        }

        public DbSet<ProgramEntity> ProgramEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramEntity>()
                .ToContainer("Providers");

            modelBuilder.Entity<ProgramEntity>()
                .Property(f => f.Id)
                .HasConversion<string>()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<ProgramEntity>().OwnsMany(d => d.Skills);
            modelBuilder.Entity<ProgramEntity>().OwnsOne(d => d.AdditionalInformation);
            modelBuilder.Entity<ProgramEntity>().OwnsOne(d => d.ApplicationForm);
            modelBuilder.Entity<ProgramEntity>().OwnsOne(d => d.WorkFLow);
        }
    }
}
