
using Microsoft.AspNetCore.Identity;
using WebApiNet.Models;

namespace WebApiNet.Data;

public class LoadDatabase
{
    public static async Task InsertDataAsync(ApplicationDbContext context, UserManager<User> userManager)
    {
        if(!userManager.Users.Any())
        {
            var user = new User
            {
                Name = "Leonel",
                LastName = "Marquez",
                UserName = "leomarqz",
                Email = "leomarqz2020@gmail.com",
                PhoneNumber = "123456789",
            };

            await userManager.CreateAsync(user, password: "Admin@LeonMarqz123");
        }

        if(!context.Properties.Any())
        {
            await context.Properties.AddRangeAsync(
                new Property
                {
                    Name = "Beach House",
                    Address = "Avn. Trinity 1",
                    Price = 60700M,
                    CreatedAt = DateTime.Now
                },
                new Property
                {
                    Name = "Summer  House",
                    Address = "Avn. Trinity 1",
                    Price = 55500M,
                    CreatedAt = DateTime.Now
                },
                new Property
                {
                    Name = "Winter House",
                    Address = "Avn. Rock",
                    Price = 100100M,
                    CreatedAt = DateTime.Now
                }
            );
            await context.SaveChangesAsync();
        }
    }
}