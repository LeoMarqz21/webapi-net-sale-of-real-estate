using AutoMapper;
using WebApiNet.Dtos.User;
using WebApiNet.Models;

namespace WebApiNet.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ResponseUserDto>();
            CreateMap<RequestUserRegisterDto, User>();
        }
    }
}