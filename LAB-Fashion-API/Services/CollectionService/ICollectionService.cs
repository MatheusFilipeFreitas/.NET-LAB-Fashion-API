using LAB_Fashion_API.Dto.CollectionDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.CollectionService
{
    public interface ICollectionService
    {
        Task<ServiceResponse<List<GetCollectionDto>>> GetAllCollections(PaginationFilter filter, String route, StatusType status);
        Task<ServiceResponse<GetCollectionDto>> GetById(int id);
        Task<ServiceResponse<GetCollectionDto>> AddCollection(AddCollectionDto newCollection);
        Task<ServiceResponse<GetCollectionDto>> UpdateCollection(int id, UpdateCollectionDto updateCollection);
        Task<ServiceResponse<GetCollectionDto>> UpdateCollectionStatus(int id, StatusType status);
        Task<ServiceResponse<GetCollectionDto>> DeleteCollection(int id);
    }
}
