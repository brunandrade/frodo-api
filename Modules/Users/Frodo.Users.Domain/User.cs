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

    public User(string name, string email, string phone) : this()
    {
        Name = name;
        Email = email;
        Phone = phone;
       // Password = PasswordUtils.HashPassword(password);
        Active = false;
        AddVerificationToken();
        ChangeStatus(UserStatusEnum.Pending);
    }

    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }
    //public string Password { get; protected set; }
    public bool Active { get; protected set; }
    public UserStatusEnum Status { get; protected set; }
    public ICollection<UserVerificationToken> VerificationTokens { get; protected set; }

    public void AddVerificationToken()
        => VerificationTokens.Add(new UserVerificationToken(Id));

    //public bool ValidatePassword(string password)
    //    => Password == PasswordUtils.HashPassword(password);

    private void ChangeStatus(UserStatusEnum userStatus)
    {
        Status = userStatus;
        UpdatedIn = DateTime.Now;
    }
}