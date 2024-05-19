using DataContext;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.IServices;

namespace Services
{
    public class WalkDifficultyService : IWalkDifficultyService
    {
        private readonly WalksDbContext dbContext;

        public WalkDifficultyService(WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WalkDifficulty> Get(Guid id)
        {
            WalkDifficulty walkDifficulty = await dbContext.WalkDifficulty.FirstOrDefaultAsync(wd => wd.Id == id);
            if (walkDifficulty == null)
            {
                return null;
            }
            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAll()
        {
            List<WalkDifficulty> walkDifficulties = await dbContext.WalkDifficulty.ToListAsync();
            return walkDifficulties;
        }

        public async Task<WalkDifficulty> Update(Guid id, WalkDifficulty walkDifficulty)
        {
            WalkDifficulty target = await dbContext.WalkDifficulty.FirstOrDefaultAsync(wd => wd.Id == id);
            if (target == null)
            {
                return null;
            }
            target.Code = walkDifficulty.Code;

            dbContext.WalkDifficulty.Update(target);
            await dbContext.SaveChangesAsync();
            return target;
        }
        public async Task<WalkDifficulty> Add(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = new Guid();
            await dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }
        public async Task<WalkDifficulty> Delete(Guid id)
        {
            WalkDifficulty walkDifficulty = await dbContext.WalkDifficulty.FirstOrDefaultAsync(wd => wd.Id == id);
            if (walkDifficulty == null)
            {
                return null;
            }
            dbContext.Remove(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }
    }
}
