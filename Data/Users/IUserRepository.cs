
using WebApiNet.Dtos.User;

namespace WebApiNet.Data.Users;

public interface IUserRepository
{
    ///<summary>
    ///This method find a user by userId
    ///</summary>
    ///<returns>
    ///Returns an instance of type ReponseUserDto
    ///</returns>
    Task<ReponseUserDto> FindByIdAsync(int id);
    Task<ReponseUserDto> LoginAsync(RequestUserLoginDto user);
    Task<ReponseUserDto> RegisterAsync(RequestUserRegisterDto user);
}