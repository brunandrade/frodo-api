using Core.Data.Mapping;
using Frodo.Pets.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class MedicationMap : BaseMap<Medication>
{
    public override void Configure(EntityTypeBuilder<Medication> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(true);
        builder.Property(x => x.Mandatory).IsRequired(true);
        builder.Property(x => x.IsVaccine).IsRequired(true);
    }
}