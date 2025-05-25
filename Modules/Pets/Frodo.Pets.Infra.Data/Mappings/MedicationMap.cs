using Core.Data.Mapping;
using Frodo.Pets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class MedicationMap : BaseMap<Medication>
{
    public override void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.ToTable("Medications", schema: "Pets");

        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Description).IsRequired(true);
        builder.Property(x => x.TakenIn).HasColumnType("timestamp without time zone").IsRequired(true);
        builder.Property(x => x.Frequency).IsRequired(true).HasConversion<string>();
        builder.Property(x => x.Quantity).IsRequired(false);
        builder.Property(x => x.Duration).IsRequired(true);
        builder.Property(x => x.OtherDuration).IsRequired(false);
    }
}