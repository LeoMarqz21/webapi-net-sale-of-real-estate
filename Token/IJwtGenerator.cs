
using WebApiNet.Models;

namespace WebApiNet.Token;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}