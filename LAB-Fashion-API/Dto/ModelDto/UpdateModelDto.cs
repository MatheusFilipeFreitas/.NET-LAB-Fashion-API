using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;

namespace LAB_Fashion_API.Dto.ModelDto
{
    public class UpdateModelDto
    {
        [Required(ErrorMessage = "É requerido o Nome!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "É requerido o Identificador de Coleção!")]
        public int CollectionId { get; set; }
        [Required(ErrorMessage = "É requerido o Tipo!")]
        public ModelType Type { get; set; }
        [Required(ErrorMessage = "É requerido o Layout!")]
        public LayoutType Layout { get; set; }
    }
}
