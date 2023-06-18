using LAB_Fashion_API.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    public class User : Person
    {
        [NotNull]
        public string Email { get; set; } = string.Empty;
        [NotNull]
        public UserType Type { get; set; } = UserType.Other;
        [NotNull]
        public StatusType Status { get; set; } = StatusType.Active;
    }
}
