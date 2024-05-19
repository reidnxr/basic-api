using Models;
using Services.IServices;
using System.Linq.Expressions;

namespace Services
{
    public class UserService : IUserService
    {

        private List<User> users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                Name = "Read Only",
                Password = "1234",
                Email = "kauareidner@hotmail.com",
                Roles = new List<string>()
                {
                    Role.Read.ToString()
                },
                FirstName = "Read",
                LastName = "Only"
            },
            new User()
            {
                Id = Guid.NewGuid(),
                Name = "Read Write",
                Password = "1234",
                Email = "kauareidner@outlook.com",
                Roles = new List<string>()
                {
                    Role.Read.ToString(), Role.Write.ToString()
                },
                FirstName = "Read",
                LastName = "Write"
            }
        };



        public async Task<User> Authentication(string email, string password)
        {
            var user = users.Find(
                                x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) 
                                && x.Password.Equals(password, StringComparison.InvariantCultureIgnoreCase)
                                );

            return user;
        }
    }
}
