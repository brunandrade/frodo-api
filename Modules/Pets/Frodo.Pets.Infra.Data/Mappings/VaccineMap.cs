using Core.Data.Mapping;
using Frodo.Pets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class VaccineMap : BaseMap<Vaccine>
{
    public override void Configure(EntityTypeBuilder<Vaccine> builder)
    {
        builder.ToTable("Vaccines", schema: "Pets");

        base.Configure(builder);
        builder.Property(x => x.PetId).IsRequired(true);
        builder.Property(x => x.Type).IsRequired(true).HasConversion<string>();
        builder.Property(x => x.Frequency).IsRequired(true).HasConversion<string>();
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(false);
        builder.Property(x => x.DoctorName).IsRequired(false);
        builder.Property(x => x.Laboratory).IsRequired(false);

        builder.HasMany(x => x.Dates);
    }
}