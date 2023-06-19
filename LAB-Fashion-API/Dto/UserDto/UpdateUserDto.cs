using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace LAB_Fashion_API.Dto.UserDto
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "É obrigatório o Nome!")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório o Gênero!")]
        public string Sex { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório a Data de Nascimento!")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "É obrigatório o Número do Telefone!")]
        public string Phone { get; set; } = string.Empty;
        [Required(ErrorMessage = "É obrigatório o Tipo de Usuário!")]
        public UserType Type { get; set; } = UserType.Other;
        [Required(ErrorMessage = "É obrigatórioi o Status!")]
        [EnumDataType(typeof(StatusType), ErrorMessage = "Status precisa ser ou Inactive ou Active")]
        public StatusType Status { get; set; }
    }
}
