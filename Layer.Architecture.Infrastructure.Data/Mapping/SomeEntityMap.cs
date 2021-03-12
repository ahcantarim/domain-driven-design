using Layer.Architecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Architecture.Infrastructure.Data.Mapping
{
    public class SomeEntityMap : IEntityTypeConfiguration<SomeEntity>
    {
        public void Configure(EntityTypeBuilder<SomeEntity> builder)
        {
            builder.ToTable("SomeEntity");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.SomeValue)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("SomeValue")
                .HasColumnType("varchar(255)");
        }
    }
}
