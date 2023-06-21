using LAB_Fashion_API.Dto.ModelDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Services.UriService;
using Microsoft.EntityFrameworkCore;

namespace LAB_Fashion_API.Services.ModelService
{
    public class ModelService : IModelService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public ModelService(DataContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
        }

        private string ErrorMessage(int code)
        {
            switch (code)
            {
                case 1:
                    return "Modelo com o Id requesitado não foi encontrado!";

                case 2:
                    return "Nome já cadastrado!";

                case 3:
                    return "Coleção com o Id requesitado não foi encontrado!";
            }
            return null;
        }

        public async Task<ServiceResponse<GetModelDto>> AddModel(AddModelDto newModel)
        {
            var serviceResponse = new ServiceResponse<GetModelDto>();
            try
            {
                var collectionFound = await _context.Collections.FirstOrDefaultAsync(collection => collection.Id == newModel.CollectionId);
                var model = _mapper.Map<Model>(newModel);
                model.Collection = collectionFound;
                if (await _context.Models.FirstOrDefaultAsync(m => m.Name == newModel.Name) is not null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(2);
                    return serviceResponse;
                }
                else if(collectionFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(3);
                    return serviceResponse;
                }
                _context.Models.Add(model);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetModelDto>(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetModelDto>>> GetAllModels(PaginationFilter filter, string route, LayoutType layout)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Models
                .Select(m => _mapper.Map<GetModelDto>(m))
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
            if(layout == LayoutType.Bordado || layout == LayoutType.Estampa || layout == LayoutType.Liso)
            {
                pagedData = await _context.Models
                    .Where(m => m.Layout == layout)
                    .Select(m => _mapper.Map<GetModelDto>(m))
                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                    .Take(validFilter.PageSize)
                    .ToListAsync();
            }
            var totalRecords = await _context.Models.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedReponse<GetModelDto>(pagedData, validFilter, totalRecords, _uriService, route);
            return pagedResponse;
        }

        public async Task<ServiceResponse<GetModelDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetModelDto>();
            var model = await _context.Models.FirstOrDefaultAsync(model => model.Id == id);
            if(model is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            }
            serviceResponse.Data = _mapper.Map<GetModelDto>(model);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetModelDto>> UpdateModel(int id, UpdateModelDto updateModel)
        {
            var serviceResponse = new ServiceResponse<GetModelDto>();
            try
            {
                var collectionFound = await _context.Collections.FirstOrDefaultAsync(c => c.Id == updateModel.CollectionId);
                var modelFound = await _context.Models.FirstOrDefaultAsync(m => m.Id == id);
                if(modelFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(1);
                    return serviceResponse;
                }
                else if (await _context.Models.FirstOrDefaultAsync(model => model.Name == updateModel.Name && model.Id != id) is not null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(2);
                    return serviceResponse;
                }
                if(collectionFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(3);
                    return serviceResponse;
                }
                modelFound.Name = updateModel.Name;
                modelFound.CollectionId = updateModel.CollectionId;
                modelFound.Collection = collectionFound;
                modelFound.Layout = updateModel.Layout;
                modelFound.Type = updateModel.Type;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetModelDto>(modelFound);
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetModelDto>> DeleteModel(int id)
        {
            var serviceResponse = new ServiceResponse<GetModelDto>();
            var model = await _context.Models.FirstOrDefaultAsync(model => model.Id == id);
            if(model is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            }
            _context.Remove(model);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetModelDto>(model);
            return serviceResponse;
        }
    }
}
