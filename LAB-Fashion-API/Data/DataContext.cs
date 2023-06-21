using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Collection> Collections => Set<Collection>();
        public DbSet<Model> Models => Set<Model>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cryptographySystem = new System.Security.Cryptography.HMACSHA256();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Birthday = new DateTime(1999, 06, 05),
                    Cpf = "99999999999",
                    Cnpj = null,
                    Sex = "Masculino",
                    Type = Enums.UserType.Administrator,
                    Phone = "55999999999",
                    Email = "adm@adm.com",
                    Status = Enums.StatusType.Active,
                    PasswordSalt = cryptographySystem.Key,
                    PasswordHash = cryptographySystem
                        .ComputeHash(System.Text.Encoding.UTF8.GetBytes("adm1234"))
                },
                new User
                {
                    Id = 2,
                    Name = "Matheus",
                    Birthday = new DateTime(1999, 08, 31),
                    Cpf = "999999991522",
                    Cnpj = null,
                    Sex = "Masculino",
                    Type = Enums.UserType.Creator,
                    Phone = "55999999666",
                    Email = "matheus@email.com",
                    Status = Enums.StatusType.Active,
                    PasswordSalt = cryptographySystem.Key,
                    PasswordHash = cryptographySystem
                        .ComputeHash(System.Text.Encoding.UTF8.GetBytes("matheus123"))
                },
                new User
                {
                    Id = 3,
                    Name = "Emilly",
                    Birthday = new DateTime(1996, 07, 20),
                    Cpf = "999999991212",
                    Cnpj = null,
                    Sex = "Feminino",
                    Type = Enums.UserType.Manager,
                    Phone = "55999995566",
                    Email = "emilly@email.com",
                    Status = Enums.StatusType.Active,
                    PasswordSalt = cryptographySystem.Key,
                    PasswordHash = cryptographySystem
        .ComputeHash(System.Text.Encoding.UTF8.GetBytes("emilly123"))
                },
                new User
                {
                    Id = 4,
                    Name = "Usuario",
                    Birthday = new DateTime(1983, 06, 21),
                    Cpf = "999556999999",
                    Cnpj = null,
                    Sex = "Feminino",
                    Type = Enums.UserType.Other,
                    Phone = "55999922399",
                    Email = "user@email.com",
                    Status = Enums.StatusType.Inactive,
                    PasswordSalt = cryptographySystem.Key,
                    PasswordHash = cryptographySystem
        .ComputeHash(System.Text.Encoding.UTF8.GetBytes("user123"))
                },
                new User
                {
                    Id = 5,
                    Name = "Carlos",
                    Birthday = new DateTime(1992, 05, 11),
                    Cpf = null,
                    Cnpj = "12999444000122",
                    Sex = "Masculino",
                    Type = Enums.UserType.Creator,
                    Phone = "55999991624",
                    Email = "carlos@email.com",
                    Status = Enums.StatusType.Active,
                    PasswordSalt = cryptographySystem.Key,
                    PasswordHash = cryptographySystem
        .ComputeHash(System.Text.Encoding.UTF8.GetBytes("carlos123"))
                });

            modelBuilder.Entity<Collection>().HasData(
                new Collection 
                {
                    Id = 1,
                    Name = "Coleção 1",
                    Accountable = 1,
                    Budget = 50000,
                    Brand = "Adidas",
                    Release = new DateTime(2025, 04, 02),
                    Season = Enums.Seasons.Summer,
                    Status = Enums.StatusType.Active,
                    UserId = 1
                },
                new Collection
                {
                    Id = 2,
                    Name = "Coleção 2",
                    Accountable = 2,
                    Budget = 100000,
                    Brand = "Nike",
                    Release = new DateTime(2030, 02, 17),
                    Season = Enums.Seasons.Winter,
                    Status = Enums.StatusType.Inactive,
                    UserId = 2
                },
                new Collection
                {
                    Id = 3,
                    Name = "Coleção 3",
                    Accountable = 1,
                    Budget = 200000,
                    Brand = "Shein",
                    Release = new DateTime(2055, 01, 10),
                    Season = Enums.Seasons.Autumn,
                    Status = Enums.StatusType.Active,
                    UserId = 1
                },
                new Collection
                {
                    Id = 4,
                    Name = "Coleção 4",
                    Accountable = 4,
                    Budget = 45000,
                    Brand = "Renner",
                    Release = new DateTime(2045, 10, 10),
                    Season = Enums.Seasons.Spring,
                    Status = Enums.StatusType.Active,
                    UserId = 4
                },
                new Collection
                {
                    Id = 5,
                    Name = "Coleção 5",
                    Accountable = 3,
                    Budget = 1000,
                    Brand = "Insider",
                    Release = new DateTime(2042, 02, 12),
                    Season = Enums.Seasons.Summer,
                    Status = Enums.StatusType.Active,
                    UserId = 3
                });

            modelBuilder.Entity<Model>().HasData(
                new Model
                {
                    Id = 1,
                    Name = "Modelo 1",
                    CollectionId = 1,
                    Layout = Enums.LayoutType.Estampa,
                    Type = Enums.ModelType.Boné
                },
                new Model
                {
                    Id = 2,
                    Name = "Modelo 2",
                    CollectionId = 1,
                    Layout = Enums.LayoutType.Liso,
                    Type = Enums.ModelType.Boné
                },
                new Model
                {
                    Id = 3,
                    Name = "Modelo 3",
                    CollectionId = 3,
                    Layout = Enums.LayoutType.Bordado,
                    Type = Enums.ModelType.Calça
                },
                new Model
                {
                    Id = 4,
                    Name = "Modelo 4",
                    CollectionId = 2,
                    Layout = Enums.LayoutType.Estampa,
                    Type = Enums.ModelType.Camisa
                },
                new Model
                {
                    Id = 5,
                    Name = "Modelo 5",
                    CollectionId = 5,
                    Layout = Enums.LayoutType.Liso,
                    Type = Enums.ModelType.Calçados
                });
        }
    }
}
