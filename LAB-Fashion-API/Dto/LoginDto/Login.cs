using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Dto.LoginDto
{
    public class Login
    {
        [Required(ErrorMessage = "É requerido o Email!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "É requerida a Senha!")]
        public string Password { get; set; } = string.Empty;
    }
}
