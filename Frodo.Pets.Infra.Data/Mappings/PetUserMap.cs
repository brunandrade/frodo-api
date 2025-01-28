using Core.Data.Mapping;
using Frodo.Pets.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Pets.Infra.Data.Mappings;

public class PetUserMap : BaseMap<PetUser>
{
    public override void Configure(EntityTypeBuilder<PetUser> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.PetId).IsRequired(true);
    }
}