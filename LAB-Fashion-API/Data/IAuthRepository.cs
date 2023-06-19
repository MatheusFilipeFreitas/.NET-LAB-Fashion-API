using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Data
{
    public interface IAuthRepository
    {
        User Register(User user , string password);
        Task<ServiceResponse<string>> Login(string email, string password);
    }
}
