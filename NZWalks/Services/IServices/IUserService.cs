using Models;

namespace Services.IServices
{
    public interface IUserService
    {
        Task<User> Authentication(string email, string password);
    }
}
