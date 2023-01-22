
using Microsoft.AspNetCore.Identity;

namespace WebApiNet.Models;

public class User : IdentityUser
{
    public string Name { get; set; }
    public string LastName { get; set; }
}