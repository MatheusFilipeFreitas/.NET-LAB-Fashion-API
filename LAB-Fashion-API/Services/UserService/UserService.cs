using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Errors.User;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Errors;

namespace LAB_Fashion_API.Services.UserService
{
    public class UserService : IUserService
    {

        private static List<User> users = new List<User> {};
        
        public async Task<ServiceResponse<User>> AddUser(User user)
        {
            var serviceResponse = new ServiceResponse<User>();
            var errors = new List<UserErrorMessages>();
            users.Add(user);
            serviceResponse.Data = user;
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<User>>();
            var errors = new List<UserErrorMessages>();
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<User>();
            var errors = new List<UserErrorMessages>();
            var user = users.FirstOrDefault(user => user.Id == id);
            if(user is null)
            {
                errors.Add(UserErrorMessages.NotFound);
                serviceResponse.Success = false;
                serviceResponse.Messages = errors;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> UpdateUser(int id, User user)
        {
            var serviceResponse = new ServiceResponse<User>();
            var errors = new List<UserErrorMessages>();
            var userFound = users.FirstOrDefault(user => user.Id == id);
            if(userFound is null)
            {
                errors.Add(UserErrorMessages.NotFound);
                serviceResponse.Success = false;
                serviceResponse.Messages = errors;
            }
            else
            {
                userFound = user;
                serviceResponse.Data = userFound;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> UpdateUserStatus(int id, StatusType status)
        {
            var serviceResponse = new ServiceResponse<User>();
            var errors = new List<UserErrorMessages>();
            var userFound = users.FirstOrDefault(user => user.Id == id);
            if (userFound is null)
            {
                errors.Add(UserErrorMessages.NotFound);
                serviceResponse.Success = false;
                serviceResponse.Messages = errors;
            }
            else
            {
                userFound.Status = status;
                serviceResponse.Data = userFound;
            }

            return serviceResponse;
        }
    }
}
