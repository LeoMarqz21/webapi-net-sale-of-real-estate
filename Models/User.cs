
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebApiNet.Models;

public class User : IdentityUser
{
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string LastName { get; set; }
}