using LAB_Fashion_API.Enums;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Dto.ModelDto
{
    public class GetModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollectionId { get; set; }
        public ModelType Type { get; set; }
        public LayoutType Layout { get; set; }
    }
}
