using System.Configuration;
using Microsoft.Data.Entity;

namespace OrmBattle.EF7Model
{
    public partial class PerformanceTestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(ConfigurationManager.ConnectionStrings["PerformanceTest"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Simplest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value).HasDefaultValue(0L);
            });
        }

        public virtual DbSet<Simplest> Simplests { get; set; }

        // Unable to generate entity type for table 'dbo.KeyTable'. Please see the warning messages.
    }
}