using LAB_Fashion_API.Dto.User;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.CollectionService
{
    public interface ICollectionService
    {
        ServiceResponse<List<Collection>> GetAllCollections();
        ServiceResponse<Collection> GetById(int id);
        ServiceResponse<Collection> AddCollection(Collection collection);
        ServiceResponse<Collection> UpdateCollection(int id, Collection updateCollection);
        ServiceResponse<Collection> UpdateCollectionStatus(int id, StatusType status);
        void DeleteCollection(int id);
    }
}
