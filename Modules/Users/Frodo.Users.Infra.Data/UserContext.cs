using Core.Data.UnitOfWork;
using Frodo.Users.Domain;
using Frodo.Users.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Users.Infra.Data;

public class UserContext : DbContext, IUnitOfWork
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserVerificationToken> VerificationTokens { get; set; }

    public async Task<bool> Commit(CancellationToken cancellationToken)
        => await SaveChangesAsync(cancellationToken) > 0;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Users");
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new UserVerificationTokenMap());
        base.OnModelCreating(modelBuilder);
    }
}