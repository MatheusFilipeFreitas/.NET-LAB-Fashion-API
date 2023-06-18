using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetById(int id);
        User AddUser(User user);
        User UpdateUser(int id, User user);
        User UpdateUserStatus(int id, StatusType status);
    }
}
