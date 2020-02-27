using CS.Ems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS.Ems.Infrastructure.Data.Mappings
{
    public class ModuleMap : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder
                .ToTable("##CS_Modules");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

        }
    }
}
