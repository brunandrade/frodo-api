using Core.Domain.DomainObjects;
using Frodo.Pets.Domain.Enums;

namespace Frodo.Pets.Domain;

public class Medication : Entity
{
    public Medication()
    {

    }

    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public DateTime TakenIn { get; protected set; }
    public FrequencyEnum Frequency { get; protected set; }
    public string? Quantity { get; protected set; }
    public DurationEnum Duration { get; protected set; }
    public string? OtherDuration { get; protected set; }
}