using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<List<GetUserDto>>> GetAllUsers(PaginationFilter filter, String route, StatusType status);
        Task<ServiceResponse<GetUserDto>> GetById(int id);
        Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser);
        Task<ServiceResponse<GetUserDto>> UpdateUser(int id, UpdateUserDto updateUser);
        Task<ServiceResponse<GetUserDto>> UpdateUserStatus(int id, StatusType status);
    }
}
