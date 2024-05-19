using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.IServices
{
    public interface IWalkService
    {
        Task<IEnumerable<Walk>> GetAll();
        Task<Walk> Get(Guid id);
        Task<Walk> Add(Walk walk);
        Task<Walk> Update(Walk walk, Guid id);
        Task<Walk> Delete(Guid id);
    }
}
