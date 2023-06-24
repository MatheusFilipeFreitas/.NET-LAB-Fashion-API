using AutoMapper.Configuration.Annotations;
using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public User? User { get; set; }
        [NotNull]
        public int UserId { get; set; }
        [NotNull]
        public int? Accountable { get; set; }
        [NotNull]
        public string Brand { get; set; } = string.Empty;
        [NotNull]
        public double Budget { get; set; }
        [NotNull]
        [Column(TypeName = "Date")]
        public DateTime Release { get; set; }
        [NotNull]
        public Seasons Season { get; set; }
        [NotNull]
        public StatusType Status { get; set; } = StatusType.Active;
        public List<Model>? Models { get; set; }

    }
}
