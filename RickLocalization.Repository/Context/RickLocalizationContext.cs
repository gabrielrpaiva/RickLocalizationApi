using Microsoft.EntityFrameworkCore;
using RickLocalization.Domain.Entities;
using System.Reflection;

namespace RickLocalization.Repository.Context
{
    public class RickLocalizationContext : DbContext
    {

        public RickLocalizationContext(DbContextOptions<RickLocalizationContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(RickLocalizationContext)));
        }

        public DbSet<HumansEntity> HumansEntity { get; set; }

        public DbSet<DimensionsEntity> DimensionsEntity { get; set; }

        public DbSet<HumansByDimensionsEntity> HumansByDimensionsEntity { get; set; }
    }
}
