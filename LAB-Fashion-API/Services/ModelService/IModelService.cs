using LAB_Fashion_API.Dto.CollectionDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.ModelService
{
    public interface IModelService
    {
        Task<ServiceResponse<List<Model>>> GetAllModels(PaginationFilter filter, String route, StatusType status);
        Task<ServiceResponse<Model>> GetById(int id);
        Task<ServiceResponse<Model>> AddModel(Model newModel);
        Task<ServiceResponse<Model>> UpdateModel(int id, Model updateModel);
        Task<ServiceResponse<Model>> DeleteModel(int id);
    }
}
