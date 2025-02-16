using Core.Domain.DomainObjects;

namespace Frodo.Users.Domain;

public class UserVerificationToken : Entity
{
    public UserVerificationToken()
    {

    }

    public UserVerificationToken(Guid userId, string verificationToken, DateTime expiresOn) : this()
    {
        UserId = userId;
        VerificationToken = verificationToken;
        ExpiresOn = expiresOn;
    }

    public Guid UserId { get; protected set; }
    public string VerificationToken { get; protected set; }
    public DateTime ExpiresOn { get; protected set; }
}