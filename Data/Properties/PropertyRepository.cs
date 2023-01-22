using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiNet.Exceptions;
using WebApiNet.Models;
using WebApiNet.Token;

namespace WebApiNet.Data.Properties;

public class PropertyRepository : IPropertyRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUserLogin _userLogin;
    private readonly UserManager<User> _userManager;
    public PropertyRepository(ApplicationDbContext context, IUserLogin userLogin, UserManager<User> userManager)
    {
        _userManager = userManager;
        _context = context;
        _userLogin = userLogin;
    }

    public async Task CreateAsync(Property property)
    {
        User user = await _userManager
            .FindByNameAsync(_userLogin.GetUserLogin());
        if(user is null) 
            throw new UserNotFoundException("User not found");
        property.CreatedAt = DateTime.Now;
        property.UserId = Guid.Parse(user.Id);
    }

    public async Task DeleteAsync(int id)
    {
        var property = await _context.Properties.FirstOrDefaultAsync(x => x.Id == id);
        if(property is null)
            throw new PropertyNotFoundException("Property not found");
        _context.Properties.Remove(property);
    }

    public Task<Property> FindByIdAsync(int id)
    {
        return _context.Properties.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Property>> GetAllAsync()
    {
        return await _context.Properties.ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
