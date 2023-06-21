using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace LAB_Fashion_API.Dto.UserDto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = new DateTime();
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserType Type { get; set; } = UserType.Other;
        public StatusType Status { get; set; }
    }
}
