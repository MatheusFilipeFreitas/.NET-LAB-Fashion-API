using AutoMapper.Configuration.Annotations;
using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Dto.CollectionDto
{
    public class UpdateCollectionDto
    {
        public string Name { get; set; }
        public int Accountable { get; set; }
        public string Brand { get; set; }
        public double Budget { get; set; }
        public DateTime Release { get; set; }
        public Seasons Season { get; set; }
    }
}
