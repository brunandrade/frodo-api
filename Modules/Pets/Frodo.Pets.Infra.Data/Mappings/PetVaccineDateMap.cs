using Core.Data.Mapping;
using Frodo.Pets.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class PetVaccineDateMap : BaseMap<PetVaccineDate>
{
    public override void Configure(EntityTypeBuilder<PetVaccineDate> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.PetVaccineId).IsRequired(true);
        builder.Property(x => x.RevaccinateIn).IsRequired(false);
    }
}
