using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.CollectionService
{
    public interface ICollectionService
    {
        Task<ServiceResponse<List<Collection>>> GetAllCollections(StatusType status);
        Task<ServiceResponse<Collection>> GetById(int id);
        Task<ServiceResponse<Collection>> AddCollection(Collection collection);
        Task<ServiceResponse<Collection>> UpdateCollection(int id, Collection updateCollection);
        Task<ServiceResponse<Collection>> UpdateCollectionStatus(int id, StatusType status);
        Task<ServiceResponse<Collection>> DeleteCollection(int id);
    }
}
