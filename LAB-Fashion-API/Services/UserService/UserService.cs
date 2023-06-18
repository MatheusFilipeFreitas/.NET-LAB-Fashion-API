using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Errors.User;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Errors;
using LAB_Fashion_API.Dto.User;
using AutoMapper;

namespace LAB_Fashion_API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly HttpContextAccessor _contextAccessor;

        public UserService(DataContext context, IMapper mapper, HttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        public async Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var errors = new List<UserErrorMessages>();
            var user = _mapper.Map<User>(newUser);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDto>>();
            var errors = new List<UserErrorMessages>();
            serviceResponse.Data = users;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
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

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(int id, AddUserDto updateUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
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

        public async Task<ServiceResponse<GetUserDto>> UpdateUserStatus(int id, StatusType status)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
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
