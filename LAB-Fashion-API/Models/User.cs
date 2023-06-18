using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : Person
    {
        /*
        public User(string name, string sex, DateTime birthDay, string? cpf, string? cnpj, string phone, string email, UserType type)
            :base(name, sex, birthDay, cpf, cnpj, phone)
        {
            Email = email;
            Type = type;
        }
        */
        public string Email { get; set; } = string.Empty;
        public UserType Type { get; set; } = UserType.Other;
        public StatusType Status { get; set; } = StatusType.Active;
    }
}
