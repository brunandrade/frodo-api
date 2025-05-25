using Core.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.Mapping;

public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.CreatedIn)
            .HasColumnType("timestamp without time zone")
            .IsRequired(true);

        builder.Property(x => x.UpdatedIn)
            .HasColumnType("timestamp without time zone")
            .IsRequired(true);

        builder.Property(x => x.DeletedIn)
            .HasColumnType("timestamp without time zone")
            .IsRequired(false);
    }
}