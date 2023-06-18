using LAB_Fashion_API.Filter;

namespace LAB_Fashion_API.Services.UriService
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
