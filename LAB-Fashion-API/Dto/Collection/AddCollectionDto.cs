using LAB_Fashion_API.Enums;

namespace LAB_Fashion_API.Dto.Collection
{
    public class AddCollectionDto
    {
        public string Name { get; set; }
        public int AccountableId { get; set; }
        public string Brand { get; set; }
        public double Budget { get; set; }
        public DateTime Release { get; set; }
        public Seasons Season { get; set; }
    }
}
