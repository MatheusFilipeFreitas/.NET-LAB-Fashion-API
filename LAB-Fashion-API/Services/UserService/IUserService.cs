using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<User>>> GetAllUsers();
        Task<ServiceResponse<User>> GetById(int id);
        Task<ServiceResponse<User>> AddUser(User user);
        Task<ServiceResponse<User>> UpdateUser(int id, User user);
        Task<ServiceResponse<User>> UpdateUserStatus(int id, StatusType status);
    }
}
