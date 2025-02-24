using Core.Domain.DomainObjects;
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
        Active = false;
        AddVerificationToken();
        ChangeStatus(UserStatusEnum.Pending);
    }

    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }
    public bool Active { get; protected set; }
    public UserStatusEnum Status { get; protected set; }
    public ICollection<UserVerificationToken> VerificationTokens { get; protected set; }

    public void AddVerificationToken()
        => VerificationTokens.Add(new UserVerificationToken(Id));

    public void RemoveAllTokens()
    {
        foreach (var item in VerificationTokens)
        {
            item.Delete();
        }
    }

    public void VerifyToken(string token)
    {
        var verificationToken = VerificationTokens.First(v => v.VerificationToken == token);
        verificationToken.SetExpired();
        Active = true;
        ChangeStatus(UserStatusEnum.Registered);
    }

    private void ChangeStatus(UserStatusEnum userStatus)
    {
        Status = userStatus;
        UpdatedIn = DateTime.Now;
    }
}