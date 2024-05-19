using NZWalks.Models;

namespace NZWalks.Services.IServices
{
    public interface IWalkDifficultyService
    {
        Task<IEnumerable<WalkDifficulty>> GetAll();
        Task<WalkDifficulty> Get(Guid id);
        Task<WalkDifficulty> Update(Guid id, WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> Add(WalkDifficulty walkDifficulty);
        Task<WalkDifficulty> Delete(Guid id);
    }
}
