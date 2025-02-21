using Core.Domain.DomainObjects;
using Frodo.Common.Utils;

namespace Frodo.Users.Domain;

public class UserVerificationToken : Entity
{
    public UserVerificationToken()
    {

    }

    public UserVerificationToken(Guid userId) : this()
    {
        UserId = userId;
        VerificationToken = StringUtils.GenerateToken();
        ExpiresOn = DateTime.Now.AddMinutes(30);
    }

    public Guid UserId { get; protected set; }
    public string VerificationToken { get; protected set; }
    public DateTime ExpiresOn { get; protected set; }

    public bool IsExpired() => DateTime.Now > ExpiresOn;
}