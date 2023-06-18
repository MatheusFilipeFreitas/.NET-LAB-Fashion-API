using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users => Set<User>();
        //public DbSet<Person> Peoples => Set<Person>();
    }
}
