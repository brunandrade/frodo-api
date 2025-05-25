using Core.Data.Mapping;
using Frodo.Users.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Frodo.Users.Infra.Data.Mappings;

public class UserMap : BaseMap<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", schema: "Users");

        base.Configure(builder);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Email).IsRequired(true);
        builder.Property(x => x.PasswordSalt).IsRequired(true);
        builder.Property(x => x.PasswordHash).IsRequired(true);
        builder.Property(x => x.Active).IsRequired(true);
        builder.Property(x => x.Status).IsRequired(true);

        builder.HasMany(x => x.VerificationTokens)
           .WithOne() 
           .HasForeignKey(v => v.UserId)
           .IsRequired();
    }
}