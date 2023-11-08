using Microsoft.AspNetCore.Mvc;
using NZWalks.Models;

namespace NZWalks.Services.IServices
{
    public interface IWalkService
    {
        Task<IEnumerable<Walk>> GetAll();
        Task<Walk> Get(Guid id);
        Task<Walk> Add(Walk walk);
    }
}
