using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace LAB_Fashion_API.Dto.User
{
    public class UpdateUserStatusDto
    {
        [Required(ErrorMessage = "É necessario o Status!")]
        public StatusType Status { get; set; }
    }
}
