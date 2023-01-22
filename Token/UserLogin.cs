
using System.Security.Claims;
namespace WebApiNet.Token;

public class UserLogin : IUserLogin
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserLogin(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetUserLogin()
    {
        var username = _httpContextAccessor
            .HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        return username;
    }
}
