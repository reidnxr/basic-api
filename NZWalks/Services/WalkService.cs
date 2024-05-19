using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.DataContext;
using NZWalks.Models;
using NZWalks.Services.IServices;

namespace NZWalks.Services
{
    public class WalkService : IWalkService
    {
        private readonly NZWalksDbContext dbContext;

        public WalkService(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> Add(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> Delete(Guid id)
        {
            Walk walk = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if(walk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(walk);
            dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> Get(Guid id)
        {
            Walk walk = await dbContext.Walks.Where(w => w.Id == id)
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAll()
        {
            List<Walk> walks = await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty).
                ToListAsync();

            return walks;
        }
        public async Task<Walk> Update(Walk walk, Guid id)
        {
            Walk target = await dbContext.Walks.FirstOrDefaultAsync(w => w.Id == id);
            if(target == null)
            {
                return null;
            }

            target.WalkDifficultyId = walk.WalkDifficultyId;
            target.RegionId = walk.RegionId;
            target.Name = walk.Name;
            target.Length = walk.Length;

            dbContext.Walks.Update(target);
            await dbContext.SaveChangesAsync();
            return target;
        }
    }
}
