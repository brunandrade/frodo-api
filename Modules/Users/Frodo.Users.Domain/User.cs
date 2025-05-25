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

    public User(string name, string email, string userName, string password) : this()
    {
        Name = name;
        Email = email;
        UserName = userName;

        PasswordSalt = PasswordUtils.GenerateSalt();
        PasswordHash = PasswordUtils.HashPassword(password, PasswordSalt);

        AddVerificationToken();
        ChangeStatus(UserStatusEnum.Pending);
        Active = false;
    }

    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string UserName { get; protected set; }
    public bool Active { get; protected set; }
    public string PasswordSalt { get; protected set; }
    public string PasswordHash { get; protected set; }
    public UserStatusEnum Status { get; protected set; }
    public ICollection<UserVerificationToken> VerificationTokens { get; protected set; }

    public bool VerifyPassword(string password)
    {
        var hashed = PasswordUtils.HashPassword(password, PasswordSalt);
        return PasswordHash == hashed;
    }

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