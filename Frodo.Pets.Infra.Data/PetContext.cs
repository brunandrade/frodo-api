using Core.Data.UnitOfWork;
using Frodo.Pets.Domain.Entities;
using Frodo.Pets.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Pets.Infra.Data;

public class PetContext : DbContext, IUnitOfWork
{
    public PetContext(DbContextOptions<PetContext> options) : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<PetUser> PetUsers { get; set; }

    public async Task<bool> Commit(CancellationToken cancellationToken)
        => await SaveChangesAsync(cancellationToken) > 0;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Pets");
        modelBuilder.ApplyConfiguration(new PetMap());
        modelBuilder.ApplyConfiguration(new PetUserMap());
        base.OnModelCreating(modelBuilder);
    }
}