using LAB_Fashion_API.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Collection
    {

        public Collection(string name, int accountableId, string brand, double budget, DateTime release, Seasons season)
        {
            Name = name;
            AccountableId = accountableId;
            Brand = brand;
            Budget = budget;
            Release = release;
            Season = season;
        }

        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; } = string.Empty;
        [NotNull]
        public int AccountableId { get; set; }
        [NotNull]
        public string Brand { get; set; } = string.Empty;
        [NotNull]
        public double Budget { get; set; }
        [NotNull]
        public DateTime Release { get; set; }
        [NotNull]
        public Seasons Season { get; set; }
        [NotNull]
        public StatusType Status { get; set; } = StatusType.Active;

    }
}
