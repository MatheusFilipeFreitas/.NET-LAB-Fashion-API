using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace LAB_Fashion_API.Models
{
    [Index(nameof(Cpf), IsUnique = true)]
    [Index(nameof(Cnpj), IsUnique = true)]
    public abstract class Person
    {
        /*
        protected Person(string name, string sex, DateTime birthDay, string? cpf, string? cnpj, string phone)
        {
            Name = name;
            Sex = sex;
            Birthday = birthDay;
            Phone = phone;
            Cpf = cpf;
            Cnpj = cnpj;
        }
        */
        [Key]
        public int Id { get; set; }
        [NotNull]
        public string Name { get; set; } = string.Empty;
        [NotNull]
        public string Sex { get; set; } = string.Empty;

        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; } = new DateTime();
        public string? Cpf { get; set; }
        public string? Cnpj { get; set; }
        [NotNull]
        public string Phone { get; set; } = string.Empty;
    }
}
