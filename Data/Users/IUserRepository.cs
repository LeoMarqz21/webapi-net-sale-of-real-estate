
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
    Task<ResponseUserDto> FindByIdAsync(string userId);
    Task<ResponseUserDto> GetUserAsync();
    Task<ResponseUserDto> LoginAsync(RequestUserLoginDto userLogin);
    Task<ResponseUserDto> RegisterAsync(RequestUserRegisterDto userRegister);
}