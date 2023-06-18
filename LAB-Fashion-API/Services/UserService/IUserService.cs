using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers();
        Task<ServiceResponse<GetUserDto>> GetById(int id);
        Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(int id, AddUserDto updateUser);
        Task<ServiceResponse<GetUserDto>> UpdateUserStatus(int id, StatusType status);
    }
}
