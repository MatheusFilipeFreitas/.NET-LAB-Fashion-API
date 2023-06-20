using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.CollectionService
{
    public class CollectionService : ICollectionService
    {
        public ServiceResponse<Collection> AddCollection(Collection collection)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<List<Collection>> GetAllCollections()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Collection> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Collection> UpdateCollection(int id, Collection updateCollection)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Collection> UpdateCollectionStatus(int id, StatusType status)
        {
            throw new NotImplementedException();
        }

        public void DeleteCollection(int id)
        {
            throw new NotImplementedException();
        }
    }
}
