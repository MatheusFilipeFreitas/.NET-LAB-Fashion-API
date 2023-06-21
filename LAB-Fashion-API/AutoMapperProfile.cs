
using LAB_Fashion_API.Dto.CollectionDto;
using LAB_Fashion_API.Dto.ModelDto;
using LAB_Fashion_API.Dto.UserDto;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<Collection, GetCollectionDto>();
            CreateMap<AddCollectionDto, Collection>();
            CreateMap<UpdateCollectionDto, Collection>();

            CreateMap<Model, GetModelDto>();
            CreateMap<AddModelDto, Model>();
            CreateMap<UpdateModelDto, Model>();
        }
    }
}
