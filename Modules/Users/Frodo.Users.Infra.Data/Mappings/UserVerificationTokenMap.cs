using Core.Data.Mapping;
using Frodo.Users.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Users.Infra.Data.Mappings;

public class UserVerificationTokenMap : BaseMap<UserVerificationToken>
{
    public override void Configure(EntityTypeBuilder<UserVerificationToken> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.VerificationToken).IsRequired(true);
        builder.Property(x => x.ExpiresOn).IsRequired(true);
    }
}
