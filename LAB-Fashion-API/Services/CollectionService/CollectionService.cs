using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.CollectionService
{
    public class CollectionService : ICollectionService
    {
        public static List<Collection> collections = new List<Collection> {
                new Collection("Teste", 1, "Adidas", 32.45d, new DateTime(), Seasons.Winter),
                new Collection("Outro", 2, "Nike", 32.45d, new DateTime(), Seasons.Winter)
            };

        private string ErrorMessage(int code)
        {
            switch (code)
            {
                case 1:
                    return "Coleção com o Id requesitado não foi encontrado!";
                
                case 2:
                    return "Nome já cadastrado!";

                case 3:
                    return "Status é requerido!";
            }
            return null;
        }

        public async Task<ServiceResponse<Collection>> AddCollection(Collection collection)
        {
            var serviceResponse = new ServiceResponse<Collection>();
            if(collections.FirstOrDefault(c => c.Name == collection.Name) is not null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(2);
                return serviceResponse;
            }
            collections.Add(collection);
            serviceResponse.Data = collection;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Collection>>> GetAllCollections(StatusType status)
        {
            var serviceResponse = new ServiceResponse<List<Collection>>();
            if(status == StatusType.Active || status == StatusType.Inactive)
            {
                serviceResponse.Data = collections.FindAll(c => c.Status == status);
            }
            else
            {
                serviceResponse.Data = collections;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<Collection>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<Collection>();
            if(collections.FirstOrDefault(c => c.Id == id) is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            } 
            serviceResponse.Data = collections[id];
            return serviceResponse;
        }

        public async Task<ServiceResponse<Collection>> UpdateCollection(int id, Collection updateCollection)
        {
            var serviceResponse = new ServiceResponse<Collection>();
            if (collections.FirstOrDefault(c => c.Id == id) is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            }
            else if (collections.FirstOrDefault(c => c.Name == updateCollection.Name) is not null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(2);
                return serviceResponse;
            }
            collections[id] = updateCollection;
            serviceResponse.Data = updateCollection;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Collection>> UpdateCollectionStatus(int id, StatusType status)
        {
            var serviceResponse = new ServiceResponse<Collection>();
            if (collections.FirstOrDefault(c => c.Id == id) is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            }
            else if(status != StatusType.Active && status != StatusType.Inactive)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(3);
                return serviceResponse;
            }
            collections[id].Status = status;
            serviceResponse.Data = collections[id];
            return serviceResponse;
        }

        public async Task<ServiceResponse<Collection>> DeleteCollection(int id)
        {
            var serviceResponse = new ServiceResponse<Collection>();
            var collection = collections.FirstOrDefault(c => c.Id == id);
            if (collection is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            }
            collections.Remove(collection);
            serviceResponse.Data = collection;
            return serviceResponse;
        }
    }
}
