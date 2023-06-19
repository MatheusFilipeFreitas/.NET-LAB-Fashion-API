using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    public class Model
    {
        public Model(int id, string name, Collection? collection, int collectionId, ModelType type, LayoutType layout)
        {
            Id = id;
            Name = name;
            Collection = collection;
            CollectionId = collectionId;
            Type = type;
            Layout = layout;
        }

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
