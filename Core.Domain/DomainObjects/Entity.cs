namespace Core.Domain.DomainObjects;

public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedIn = UpdatedIn = DateTime.UtcNow;
    }

    public Guid Id { get; protected set; }
    public DateTime CreatedIn { get; protected set; }
    public DateTime UpdatedIn { get; protected set; }
    public DateTime? DeletedIn { get; protected set; }
}
