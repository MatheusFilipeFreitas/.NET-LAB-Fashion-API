using AutoMapper.Configuration.Annotations;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;
using System.ComponentModel.DataAnnotations;

namespace LAB_Fashion_API.Dto.CollectionDto
{
    public class UpdateCollectionDto
    {
        [Required(ErrorMessage = "É requerido o Nome!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "É requerido o Identificador do Responsável!")]
        public int Accountable { get; set; }
        [Required(ErrorMessage = "É requerida a Marca!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "É requerido o Orçamento!")]
        public double Budget { get; set; }
        [Required(ErrorMessage = "É requerida a Data de Lançamento!")]
        public DateTime Release { get; set; }
        [Required(ErrorMessage = "É requerida a Estação!")]
        public Seasons Season { get; set; }
    }
}
