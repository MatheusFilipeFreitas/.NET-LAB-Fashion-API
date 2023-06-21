using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Model
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; } = string.Empty;
        [NotNull]
        public Collection? Collection { get; set; }
        [NotNull]
        public int CollectionId { get; set; }
        [NotNull]
        public ModelType Type { get; set; }
        [NotNull]
        public LayoutType Layout { get; set; }
    }
}
