using LAB_Fashion_API.Errors.User;

namespace LAB_Fashion_API.Wrapper
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public List<UserErrorMessages>? Messages { get; set; }
    }
}
