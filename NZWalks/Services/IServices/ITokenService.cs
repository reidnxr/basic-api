using Models;

namespace Services.IServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
