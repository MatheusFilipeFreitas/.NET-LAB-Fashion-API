using LAB_Fashion_API.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Dto.UserDto
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "É obrigatório o Nome!")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório o Gênero!")]
        public string Sex { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório a Data de Nascimento!")]
        public DateTime Birthday { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        [Required(ErrorMessage = "É obrigatório o Número do Telefone!")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório o Email!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório o Tipo de Usuário!")]
        public UserType Type { get; set; } = UserType.Other;
        [Required(ErrorMessage = "É obrigatória a Senha!")]
        public string Password { get; set; }
    }
}
