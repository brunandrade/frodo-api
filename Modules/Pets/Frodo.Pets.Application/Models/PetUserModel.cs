namespace Frodo.Pets.Application.Models;

public record PetUserModel
{
    public Guid Id { get; set; }
    public Guid PetId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedIn { get; set; }
    public DateTime UpdatedIn { get; set; }
}
