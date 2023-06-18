using LAB_Fashion_API.Enums;
using LAB_Fashion_API.Models;

namespace LAB_Fashion_API.Services.UserService
{
    public class UserService : IUserService
    {

        private static List<User> users = new List<User> {
            new User("Teste", "Masculino", new DateTime(), "55999999999", "teste@teste.com"),
            new User("Another Teste", "Masculino", new DateTime(), "55999999955", "anotherteste@teste.com"),
        };

        public User AddUser(User user)
        {
            users.Add(user);
            return user;
        }


        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetById(int id)
        {
            var user = users.FirstOrDefault(user => user.Id == id);
            if(user is null)
            {
                throw new Exception("User not found");
            }
            return users[id];
        }

        public User UpdateUser(int id, User user)
        {
            users[id] = user;
            return user;
        }

        public User UpdateUserStatus(int id, StatusType status)
        {
            users[id].Status = status;
            return users[id];
        }
    }
}
