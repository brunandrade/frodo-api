using Frodo.Users.Domain.Enums;

namespace Frodo.Users.Application.Models;

public class UserModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
    public UserStatusEnum Status { get; set; }
    public IEnumerable<UserVerificationTokenModel> VerificationTokens { get; protected set; }
}

public class UserVerificationTokenModel
{
    public Guid UserId { get; set; }
    public string VerificationToken { get; set; }
    public DateTime ExpiresOn { get; set; }
}