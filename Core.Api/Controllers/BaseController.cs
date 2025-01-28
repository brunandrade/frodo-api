using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Api.Controllers;

public class BaseController : ControllerBase
{
    protected Guid GetUserIdFromToken(string jwtToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        if (tokenHandler.CanReadToken(jwtToken))
        {
            var jwt = tokenHandler.ReadJwtToken(jwtToken);

            if (jwt.Payload.ContainsKey("sub"))
            {
                var userId = Guid.Parse(jwt.Payload["sub"].ToString()!);
                return userId;
            }
            else
            {
                return Guid.Empty;
            }
        }
        else
        {
            return Guid.Empty;
        }
    }
}