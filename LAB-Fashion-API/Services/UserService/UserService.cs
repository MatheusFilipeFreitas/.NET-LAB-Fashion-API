using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Errors.User;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Errors;
using LAB_Fashion_API.Dto.User;
using AutoMapper;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Services.UriService;

namespace LAB_Fashion_API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public UserService(DataContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
        }

        private string ErrorMessage(int code)
        {
            switch (code)
            {
                case 1:
                    return "Cpf ou Cnpj é requerido!";

                case 2:
                    return "Cnpj já cadastrado!";

                case 3:
                    return "Cpf já cadastrado!";

                case 4:
                    return "Email já cadastrado!";

                case 5:
                    return "Não é possível preencher o Cpf e o Cnpj!";

                case 6:
                    return "Usuário com o Id requesitado não foi encontrado!";
            }
            return null;
        }

        public async Task<ServiceResponse<GetUserDto>> AddUser(AddUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var user = _mapper.Map<User>(newUser);
                if (user.Cnpj is null && user.Cpf is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(1);
                    return serviceResponse;
                }else if(user.Cnpj is not null && user.Cpf is not null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(5);
                    return serviceResponse;
                }
                else if(user.Cpf is null && user.Cnpj == _context.Users.First().Cnpj)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(2);
                    return serviceResponse;
                }else if(user.Cnpj is null && user.Cpf == _context.Users.First().Cpf)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(3);
                    return serviceResponse;
                }
                if(user.Email == _context.Users.First().Email)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(4);
                    return serviceResponse;
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetUserDto>>> GetAllUsers(PaginationFilter filter, String route)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Users
               .Select(c => _mapper.Map<GetUserDto>(c))
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();
            var totalRecords = await _context.Users.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedReponse<GetUserDto>(pagedData, validFilter, totalRecords, _uriService, route);
            return pagedResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(6);
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<GetUserDto>(user);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUser(int id, UpdateUserDto updateUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var userFound = _context.Users.FirstOrDefault(user => user.Id == id);
                if (userFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(6);
                    return serviceResponse;
                }

                userFound.Name = updateUser.Name;
                userFound.Phone = updateUser.Phone;
                userFound.Birthday = updateUser.Birthday;
                userFound.Sex = updateUser.Sex;
                userFound.Type = updateUser.Type;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetUserDto>(userFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDto>> UpdateUserStatus(int id, StatusType status)
        {
            var serviceResponse = new ServiceResponse<GetUserDto>();
            try
            {
                var userFound = _context.Users.FirstOrDefault(user => user.Id == id);
                if (userFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(6);
                    return serviceResponse;
                }

                userFound.Status = status;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetUserDto>(userFound);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return serviceResponse;
        }
    }
}
