using Core.Data.Mapping;
using Frodo.Pets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class TutorMap : BaseMap<Tutor>
{
    public override void Configure(EntityTypeBuilder<Tutor> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.PetId).IsRequired(true);
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.Active).IsRequired(true).HasDefaultValue(true);
    }
}