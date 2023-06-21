using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : Person
    {
        public string Email { get; set; } = string.Empty;
        public UserType Type { get; set; } = UserType.Other;
        public StatusType Status { get; set; } = StatusType.Active;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<Collection>? Collections { get; set; }
    }
}
