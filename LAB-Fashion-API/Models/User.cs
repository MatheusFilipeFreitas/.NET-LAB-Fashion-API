using LAB_Fashion_API.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    public class User : Person
    {
        public User(string name, string sex, DateTime birthDay, string phone, string email)
            :base(name, sex, birthDay, phone)
        {
            Email = email;
        }

        [NotNull]
        public string Email { get; set; } = string.Empty;
        public UserType Type { get; set; } = UserType.Other;
        public StatusType Status { get; set; } = StatusType.Active;
    }
}
