using Core.Data.Mapping;
using Frodo.Users.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Users.Infra.Data.Mappings;

public class UserMap : BaseMap<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Email).IsRequired(true);
        //builder.Property(x => x.Password).IsRequired(true);
        builder.Property(x => x.Active).IsRequired(true);
        builder.Property(x => x.Status).IsRequired(true);

        builder.HasMany(x => x.VerificationTokens);
    }
}