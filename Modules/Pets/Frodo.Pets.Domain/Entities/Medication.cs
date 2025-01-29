using Core.Domain.DomainObjects;

namespace Frodo.Pets.Domain.Entities;

public class Medication : Entity
{
    public Medication()
    {
        
    }

    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public bool Mandatory { get; protected set; }
    public bool IsVaccine { get; protected set; }
}