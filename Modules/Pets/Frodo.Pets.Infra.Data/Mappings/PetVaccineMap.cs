using Core.Data.Mapping;
using Frodo.Pets.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class PetVaccineMap : BaseMap<PetVaccine>
{
    public override void Configure(EntityTypeBuilder<PetVaccine> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.PetId).IsRequired(true);
        builder.Property(x => x.MedicationId).IsRequired(true);
        builder.Property(x => x.VaccinationIn).IsRequired(true);
        builder.Property(x => x.Frequency).IsRequired(true);
        builder.Property(x => x.NumberOfDays).IsRequired(false);
        builder.Property(x => x.DoctorName).IsRequired(false);
        builder.Property(x => x.Laboratory).IsRequired(false);

        builder.HasMany(x => x.Dates);
    }
}