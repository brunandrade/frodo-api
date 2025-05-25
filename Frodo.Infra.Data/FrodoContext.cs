using Core.Data;
using Core.Domain.DomainObjects;
using Frodo.Pets.Domain;
using Frodo.Pets.Infra.Data.Mappings;
using Frodo.Users.Domain;
using Frodo.Users.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Frodo.Infra.Data;

public class FrodoContext : DbContext, IAppDBContext
{
    public FrodoContext(DbContextOptions<FrodoContext> options) : base(options)
    {
    }

    public async Task<bool> Commit(CancellationToken cancellationToken)
        => await SaveChangesAsync(cancellationToken) > 0;

    public new DbSet<T> Set<T>() where T : Entity => base.Set<T>();

    public async Task AddAsync<T>(T entity, CancellationToken cancellationToken) where T : Entity
        => await base.AddAsync(entity, cancellationToken);

    public void Update<T>(T entity) where T : Entity => base.Update(entity);

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Tutor> Tutors { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }
    public DbSet<VaccineDate> VaccineDates { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<UserVerificationToken> UserVerificationTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetMap).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}