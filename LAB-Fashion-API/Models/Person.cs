using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LAB_Fashion_API.Models
{
    public abstract class Person
    {
        protected Person(string name, string sex, DateTime birthDay, string phone)
        {
            Name = name;
            Sex = sex;
            Birthday = birthDay;
            Phone = phone;
        }

        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; } = string.Empty;
        [NotNull]
        public string Sex { get; set; } = string.Empty;

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        [NotNull]
        public string Phone { get; set; } = string.Empty;
    }
}
