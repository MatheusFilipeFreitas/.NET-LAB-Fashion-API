
using LAB_Fashion_API.Dto.CollectionDto;
using LAB_Fashion_API.Dto.UserDto;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Filter;
using LAB_Fashion_API.Models;
using LAB_Fashion_API.Services.UriService;
using System.Security.Claims;

namespace LAB_Fashion_API.Services.CollectionService
{
    public class CollectionService : ICollectionService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IUserService _userService;

        public CollectionService(DataContext context, IMapper mapper, IUriService uriService, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;
            _userService = userService;
        }

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

                case 4:
                    return "Usuário (Responsável) com o Id requesitado não foi encotrado!";

                case 5:
                    return "Para realizar a operação é necessário que a coleção tenha seu status como inátiva!";

                case 6:
                    return "Para realizar a operação é necessário que a coleção não possua nenhum modelo vinculado!";
            }
            return null;
        }

        public async Task<ServiceResponse<GetCollectionDto>> AddCollection(AddCollectionDto newCollection)
        {
            //TODO: Verify valid Release Date
            var serviceResponse = new ServiceResponse<GetCollectionDto>();
            try
            {
                var userFound = await _context.Users.FirstOrDefaultAsync(user => user.Id == newCollection.Accountable);
                var collection = _mapper.Map<Collection>(newCollection);
                collection.User = userFound;
                if (await _context.Collections.FirstOrDefaultAsync(c => c.Name == collection.Name) is not null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(2);
                    return serviceResponse;
                }
                else if(userFound is null)
                {
                    serviceResponse.Success= false;
                    serviceResponse.Messages = ErrorMessage(4);
                    return serviceResponse;
                }
                _context.Collections.Add(collection);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCollectionDto>(collection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCollectionDto>>> GetAllCollections(PaginationFilter filter, String route, StatusType status)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Collections
                          .Select(c => _mapper.Map<GetCollectionDto>(c))
                          .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                          .Take(validFilter.PageSize)
                          .ToListAsync();
            if (status == StatusType.Active || status == StatusType.Inactive)
            {
                pagedData = await _context.Collections
                   .Where(c => c.Status == status)
                   .Select(c => _mapper.Map<GetCollectionDto>(c))
                   .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                   .Take(validFilter.PageSize)
                   .ToListAsync();
            }

            var totalRecords = await _context.Collections.CountAsync();

            var pagedResponse = PaginationHelper.CreatePagedReponse<GetCollectionDto>(pagedData, validFilter, totalRecords, _uriService, route);
            return pagedResponse;
        }

        public async Task<ServiceResponse<GetCollectionDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCollectionDto>();
            var collection = await _context.Collections.FirstOrDefaultAsync(collection => collection.Id == id);
            if(collection is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            } 
            serviceResponse.Data = _mapper.Map<GetCollectionDto>(collection);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCollectionDto>> UpdateCollection(int id, UpdateCollectionDto updateCollection)
        {
            //TODO: Verify valid Release Date
            var serviceResponse = new ServiceResponse<GetCollectionDto>();
            try
            {
                var userFound = await _context.Users.FirstOrDefaultAsync(user => user.Id == updateCollection.Accountable);
                var collectionFound = await _context.Collections.FirstOrDefaultAsync(collection => collection.Id == id);
                if (collectionFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(1);
                    return serviceResponse;
                }
                else if (await _context.Collections.FirstOrDefaultAsync(collection => collection.Name == updateCollection.Name && collection.Id != id) is not null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(2);
                    return serviceResponse;
                }
                if(userFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(4);
                    return serviceResponse;
                }
                collectionFound.Name = updateCollection.Name;
                collectionFound.User = userFound;
                collectionFound.Brand = updateCollection.Brand;
                collectionFound.Budget = updateCollection.Budget;
                collectionFound.Release = updateCollection.Release;
                collectionFound.Season = updateCollection.Season;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCollectionDto>(collectionFound);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCollectionDto>> UpdateCollectionStatus(int id, StatusType status)
        {
            var serviceResponse = new ServiceResponse<GetCollectionDto>();
            try
            {
                var collectionFound = await _context.Collections.FirstOrDefaultAsync(collection => collection.Id == id);
                if (collectionFound is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(1);
                    return serviceResponse;
                }
                else if (status != StatusType.Active && status != StatusType.Inactive)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Messages = ErrorMessage(3);
                    return serviceResponse;
                }

                collectionFound.Status = status;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetCollectionDto>(collectionFound);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCollectionDto>> DeleteCollection(int id)
        {
            var serviceResponse = new ServiceResponse<GetCollectionDto>();
            var collection = await _context.Collections.FirstOrDefaultAsync(collection => collection.Id == id);
            if (collection is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Messages = ErrorMessage(1);
                return serviceResponse;
            }
            else if(collection.Status == StatusType.Active)
            {
                serviceResponse.Success= false;
                serviceResponse.Messages = ErrorMessage(5);
                return serviceResponse;
            }
            //TODO: See if are any models in this collection

            _context.Remove(collection);
            await _context.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<GetCollectionDto>(collection);
            return serviceResponse;
        }
    }
}
