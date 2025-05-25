using Core.Data.Mapping;
using Frodo.Pets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class VaccineDateMap : BaseMap<VaccineDate>
{
    public override void Configure(EntityTypeBuilder<VaccineDate> builder)
    {
        builder.ToTable("VaccineDates", schema: "Pets");

        base.Configure(builder);
        builder.Property(x => x.PetVaccineId).IsRequired(true);
        builder.Property(x => x.VaccinationIn).IsRequired(true);
        builder.Property(x => x.RevaccinateIn).IsRequired(true);
    }
}