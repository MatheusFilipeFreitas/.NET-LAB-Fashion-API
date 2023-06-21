using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.ModelService
{
    public class ModelService : IModelService
    {
        public Task<ServiceResponse<Model>> AddModel(Model newModel)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Model>> DeleteModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Model>>> GetAllModels(PaginationFilter filter, string route, StatusType status)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Model>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Model>> UpdateModel(int id, Model updateModel)
        {
            throw new NotImplementedException();
        }
    }
}
