using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebApiNet.Dtos.User;
using WebApiNet.Exceptions;
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
    private readonly IMapper _mapper;

    public UserRepository(
        UserManager<User> userManager,SignInManager<User> signInManager, 
        IJwtGenerator jwtGenerator, ApplicationDbContext context, 
        IUserLogin userLogin, IMapper mapper
        )
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _userLogin = userLogin;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
    }

    public async Task FindByIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseUserDto> GetUserAsync()
    {
        User user = await _userManager.FindByNameAsync(_userLogin.GetUserLogin());
        ResponseUserDto userDto = _mapper.Map<ResponseUserDto>(user);
        userDto.Token = _jwtGenerator.GenerateToken(user);
        return userDto;
    }

    public async Task<ResponseUserDto> LoginAsync(RequestUserLoginDto userLogin)
    {
        var user = await _userManager.FindByEmailAsync(userLogin.Email);
        if(user is null)
            throw new UserNotFoundException("User not found");
        await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password,false);
        ResponseUserDto userDto = _mapper.Map<ResponseUserDto>(user);
        userDto.Token = _jwtGenerator.GenerateToken(user);
        return userDto;
    }

    public async Task<ResponseUserDto> RegisterAsync(RequestUserRegisterDto userRegister)
    {
        User user = _mapper.Map<User>(userRegister);
        await _userManager.CreateAsync(user, user.PasswordHash);
        return _mapper.Map<ResponseUserDto>(user);
    }

    Task<ResponseUserDto> IUserRepository.FindByIdAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
