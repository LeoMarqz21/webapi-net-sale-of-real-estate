using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApiNet.Dtos.User;
using WebApiNet.Models;
using WebApiNet.Token;

namespace WebApiNet.Data.Users;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserLogin _userLogin;

    public UserRepository(
        UserManager<User> userManager,SignInManager<User> signInManager, 
        IJwtGenerator jwtGenerator, ApplicationDbContext context, 
        IUserLogin userLogin
        )
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _userLogin = userLogin;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<ReponseUserDto> FindByIdAsync(int id)
    {
        var user = await _userManager.FindByNameAsync(_userLogin.GetUserLogin());
        
    }

    public Task<ReponseUserDto> LoginAsync(RequestUserLoginDto user)
    {
        throw new NotImplementedException();
    }

    public Task<ReponseUserDto> RegisterAsync(RequestUserRegisterDto user)
    {
        throw new NotImplementedException();
    }
}
