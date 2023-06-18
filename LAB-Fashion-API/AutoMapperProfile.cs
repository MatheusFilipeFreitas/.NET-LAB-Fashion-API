using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}
