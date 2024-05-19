using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalks.Models;
using NZWalks.Services.IServices;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("WalkDifficulty")]
    public class WalkDifficultyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWalkDifficultyService _walkDifficultyService;

        public WalkDifficultyController(IMapper mapper, IWalkDifficultyService walkDifficultyService)
        {
            this._mapper = mapper;
            this._walkDifficultyService = walkDifficultyService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ActionName("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var walkDifficulties = await _walkDifficultyService.GetAll();
            List<Models.DTO.WalkDifficulty> walkDifficultiesDTO = _mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulties);
            return Ok(walkDifficultiesDTO);
        }
       
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var walkDifficulty = await _walkDifficultyService.Get(id);
            if(walkDifficulty == null)
            {
                return NotFound();
            }
            Models.DTO.WalkDifficulty walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }
       
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add([FromBody] Models.DTO.AddMethod.WalkDifficulty walkDifficulty)
        {
            bool valid = IsValid(walkDifficulty);
            if (!valid)
            {
                return BadRequest(ModelState);
            }

            WalkDifficulty target = _mapper.Map<WalkDifficulty>(walkDifficulty);
            target = await _walkDifficultyService.Add(target);

            Models.DTO.WalkDifficulty walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(target);

            return CreatedAtAction(nameof(Add), walkDifficultyDTO);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        [ActionName("Update")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMethod.WalkDifficulty walkDifficulty)
        {
            bool valid = IsValid(walkDifficulty);
            if (!valid)
            {
                return BadRequest(ModelState);
            }

            WalkDifficulty target = _mapper.Map<WalkDifficulty>(walkDifficulty);
            target = await _walkDifficultyService.Update(id, target);
            
            if(target == null)
            {
                return NotFound();
            }
            Models.DTO.WalkDifficulty walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(target);
            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            WalkDifficulty walkDifficulty = await _walkDifficultyService.Delete(id);
            if(walkDifficulty == null)
            {
                return NotFound();
            }
            return Ok(walkDifficulty);
        }

        #region Private Methods

        public bool IsValid(Models.DTO.AddMethod.WalkDifficulty walkDifficulty)
        {
            bool valid = true;

            if (walkDifficulty == null)
            {
                ModelState.AddModelError(nameof(walkDifficulty), $"RalkDifficulty cannot be null.");
                valid = false;
                return valid;
            }

            if (string.IsNullOrWhiteSpace(walkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(walkDifficulty.Code), $"{nameof(walkDifficulty.Code)} cannot be null or empty or white space.");
            }

            if (ModelState.ErrorCount > 0)
            {
                valid = false;
            }

            return valid;
        }

        public bool IsValid(Models.DTO.UpdateMethod.WalkDifficulty walkDifficulty)
        {
            bool valid = true;

            if (walkDifficulty == null)
            {
                ModelState.AddModelError(nameof(walkDifficulty), $"RalkDifficulty cannot be null.");
                valid = false;
                return valid;
            }

            if (string.IsNullOrWhiteSpace(walkDifficulty.Code))
            {
                ModelState.AddModelError(nameof(walkDifficulty.Code), $"{nameof(walkDifficulty.Code)} cannot be null or empty or white space.");
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
