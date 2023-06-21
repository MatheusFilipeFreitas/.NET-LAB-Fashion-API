using LAB_Fashion_API.Dto.CollectionDto;
using LAB_Fashion_API.Dto.ModelDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB_Fashion_API.Services.ModelService
{
    public interface IModelService
    {
        Task<ServiceResponse<List<GetModelDto>>> GetAllModels(PaginationFilter filter, String route, LayoutType layout);
        Task<ServiceResponse<GetModelDto>> GetById(int id);
        Task<ServiceResponse<GetModelDto>> AddModel(AddModelDto newModel);
        Task<ServiceResponse<GetModelDto>> UpdateModel(int id, UpdateModelDto updateModel);
        Task<ServiceResponse<GetModelDto>> DeleteModel(int id);
    }
}
