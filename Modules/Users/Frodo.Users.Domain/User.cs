using Core.Domain.DomainObjects;
using Frodo.Common.Utils;
using Frodo.Users.Domain.Enums;

namespace Frodo.Users.Domain;

public class User : Entity, IAggregateRoot
{
    public User()
    {
        VerificationTokens = new List<UserVerificationToken>();
    }

    public User(string name, string email, string password) : this()
    {
        Name = name;
        Email = email;
        Password = PasswordUtils.HashPassword(password);
        Active = true;
        ChangeStatus(UserStatusEnum.Pending);
    }

    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public bool Active { get; protected set; }
    public UserStatusEnum Status { get; protected set; }
    public IEnumerable<UserVerificationToken> VerificationTokens { get; protected set; }

    public bool ValidatePassword(string password)
        => Password == PasswordUtils.HashPassword(password);

    private void ChangeStatus(UserStatusEnum userStatus)
    {
        Status = userStatus;
        UpdatedIn = DateTime.Now;
    }
}