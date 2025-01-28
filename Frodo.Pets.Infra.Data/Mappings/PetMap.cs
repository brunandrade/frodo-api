using Core.Data.Mapping;
using Frodo.Pets.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class PetMap : BaseMap<Pet>
{
    public override void Configure(EntityTypeBuilder<Pet> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Age).IsRequired(true);
        builder.Property(x => x.Gender).IsRequired(true);
        builder.Property(x => x.Weight).IsRequired(true);
        builder.Property(x => x.ImageUrl).IsRequired(false);

        builder.HasMany(x => x.PetUsers);
    }
}