using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }

        //navigation property
        public List<UserRole> UserRoles { get; set; }
    }
    public enum Roles
    {
        Read = 0,
        Write = 1,
    }
}
