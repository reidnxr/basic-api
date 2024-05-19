using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

using Services.IServices;

namespace Controllers
{
    [ApiController]
    [Route("Walks")]
    [Authorize]
    public class WalkController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWalkDifficultyService _walkDifficultyService;
        private readonly IRegionService _regionService;
        private readonly IWalkService _walkService;

        public WalkController(IMapper mapper, IWalkService walkService, IWalkDifficultyService walkDifficultyService, IRegionService regionService)
        {
            _mapper = mapper;
            _walkDifficultyService = walkDifficultyService;
            _regionService = regionService;
            _walkService = walkService;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize(Roles = "Read")]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _walkService.GetAll();
            List<Models.DTO.Walk> walksDTO = _mapper.Map<List<Models.DTO.Walk>>(walks);
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
        [Authorize(Roles = "Read")]
        public async Task<IActionResult> Get(Guid id)
        {
            Walk walk = await _walkService.Get(id);
            if (walk == null)
            {
                return NotFound();
            }
            Models.DTO.Walk walkDTO = _mapper.Map<Models.DTO.Walk>(walk);
            return Ok(walkDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Write")]
        public async Task<IActionResult> Add([FromBody] Models.DTO.AddMethod.Walk walk)
        {
            bool valid = await AddIsValid(walk);
            if (!valid)
            {
                return BadRequest(ModelState);
            }

            Walk newWalk = _mapper.Map<Walk>(walk);
            newWalk = await _walkService.Add(newWalk);

            Models.DTO.Walk walkDTO = _mapper.Map<Models.DTO.Walk>(newWalk);

            return CreatedAtAction(nameof(Get), walkDTO);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        [Authorize(Roles = "Write")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMethod.Walk walk)
        {
            bool valid = await UpdateIsValid(walk);
            if (!valid)
            {
                return BadRequest(ModelState);
            }

            Walk target = _mapper.Map<Walk>(walk);
            target = await _walkService.Update(target, id);

            if (target == null)
            {
                return NotFound();
            }
            Models.DTO.Walk walkDTO = _mapper.Map<Models.DTO.Walk>(target);
            return Ok(walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Write")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            Walk walk = await _walkService.Delete(id);
            if (walk == null)
            {
                return NotFound();
            }
            Models.DTO.Walk walkDTO = _mapper.Map<Models.DTO.Walk>(walk);

            return Ok(walkDTO);
        }

        #region Private Methods

        private async Task<bool> AddIsValid(Models.DTO.AddMethod.Walk walk)
        {
            bool valid = true;

            if (walk == null)
            {
                ModelState.AddModelError(nameof(walk), $"Walk cannot be null.");
                valid = false;
                return valid;
            }

            Region region = await _regionService.Get(walk.RegionId);
            if (region == null)
            {
                ModelState.AddModelError(nameof(walk.RegionId), $"{nameof(walk.RegionId)} is invalid.");
            }

            WalkDifficulty walkDIfficulty = await _walkDifficultyService.Get(walk.WalkDifficultyId);
            if (walkDIfficulty == null)
            {
                ModelState.AddModelError(nameof(walk.WalkDifficultyId), $"{nameof(walk.WalkDifficultyId)} is invalid.");
            }


            if (ModelState.ErrorCount > 0)
            {
                valid = false;
            }

            return valid;
        }

        private async Task<bool> UpdateIsValid(Models.DTO.UpdateMethod.Walk walk)
        {
            bool valid = true;

            if (walk == null)
            {
                ModelState.AddModelError(nameof(walk), $"Walk cannot be null.");
                valid = false;
                return valid;
            }

            Region region = await _regionService.Get(walk.RegionId);
            if (region == null)
            {
                ModelState.AddModelError(nameof(walk.RegionId), $"{nameof(walk.RegionId)} is invalid.");
            }

            WalkDifficulty walkDIfficulty = await _walkDifficultyService.Get(walk.WalkDifficultyId);
            if (walkDIfficulty == null)
            {
                ModelState.AddModelError(nameof(walk.WalkDifficultyId), $"{nameof(walk.WalkDifficultyId)} is invalid.");
            }

            if (ModelState.ErrorCount > 0)
            {
                valid = false;
            }

            return valid;
        }

        #endregion
    }
}
