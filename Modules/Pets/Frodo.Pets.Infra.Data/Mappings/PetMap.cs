using Core.Data.Mapping;
using Frodo.Pets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class PetMap : BaseMap<Pet>
{
    public override void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets", schema: "Pets");

        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Age).IsRequired(true);
        builder.Property(x => x.Gender).IsRequired(true);
        builder.Property(x => x.Weight).IsRequired(true);
        builder.Property(x => x.Race).IsRequired(true);

        builder.Property(x => x.DateOfBirth).IsRequired();

        builder.Property(x => x.MicrochipId).IsRequired(false);
        builder.Property(x => x.FavoriteFood).IsRequired(false);
        builder.Property(x => x.ImageUrl).IsRequired(false);

        builder.HasMany(x => x.Tutors);
        builder.HasMany(x => x.Vaccines);
        builder.HasMany(x => x.Medications);
    }
}