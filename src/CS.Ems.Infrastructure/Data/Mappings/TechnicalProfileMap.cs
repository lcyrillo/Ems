using CS.Ems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS.Ems.Infrastructure.Data.Mappings
{
    public class TechnicalProfileMap : IEntityTypeConfiguration<TechnicalProfile>
    {
        public void Configure(EntityTypeBuilder<TechnicalProfile> builder)
        {
            builder
                .ToTable("##CS_TechnicalProfile");

            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

        }
    }
}
