using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Collection
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; } = string.Empty;
        [NotNull]
        public int AccountableId { get; set; }
        [NotNull]
        public string Brand { get; set; } = string.Empty;
        [NotNull]
        public Double Budget { get; set; }
        [NotNull]
        public DateTime Release { get; set; }
        [NotNull]
        public Seasons Season { get; set; }
        [NotNull]
        public StatusType Status { get; set; }

    }
}
