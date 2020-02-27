using CS.Ems.Domain.Entities;
using CS.Ems.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CS.Ems.Infrastructure.Data.Context
{
    public class EmsContext : DbContext
    {
        public EmsContext(DbContextOptions<EmsContext> options) : base(options) { }

        public virtual DbSet<TechnicalProfile> TechnicalProfile { get; set; }
        public virtual DbSet<Module> Module { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TechnicalProfileMap());
            modelBuilder.ApplyConfiguration(new ModuleMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
