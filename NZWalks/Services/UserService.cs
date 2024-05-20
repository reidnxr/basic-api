using DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.IServices;
using System.Linq.Expressions;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly WalksDbContext _dbContext;

        public UserService(WalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> Authentication(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.Password == password.ToLower());

            if (user == null)
            {
                return null;
            }

            var userRoles = await _dbContext.UserRoles.Where(ur => ur.UserId == user.Id).ToListAsync();

            if(userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach(var role in userRoles)
                {
                    var userRole = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == role.Id);
                    if(userRole != null)
                    {
                        user.Roles.Add(userRole.Name);
                    }
                }
            }
            user.Password = null;
            return user;
        }
    }
}
