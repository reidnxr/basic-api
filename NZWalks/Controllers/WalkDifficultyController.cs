using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.IServices;

namespace Controllers
{
    [ApiController]
    [Route("WalkDifficulty")]
    [Authorize]
    public class WalkDifficultyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWalkDifficultyService _walkDifficultyService;

        public WalkDifficultyController(IMapper mapper, IWalkDifficultyService walkDifficultyService)
        {
            _mapper = mapper;
            _walkDifficultyService = walkDifficultyService;
        }

        [HttpGet]
        [Route("GetAll")]
        [ActionName("GetAll")]
        [Authorize(Roles = "Read")]
        public async Task<IActionResult> GetAll()
        {
            var walkDifficulties = await _walkDifficultyService.GetAll();
            List<Models.DTO.WalkDifficulty> walkDifficultiesDTO = _mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulties);
            return Ok(walkDifficultiesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
        [Authorize(Roles = "Read")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var walkDifficulty = await _walkDifficultyService.Get(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            Models.DTO.WalkDifficulty walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        [ActionName("Add")]
        [Authorize(Roles = "Write")]
        public async Task<IActionResult> Add([FromBody] Models.DTO.AddMethod.WalkDifficulty walkDifficulty)
        {
            WalkDifficulty target = _mapper.Map<WalkDifficulty>(walkDifficulty);
            target = await _walkDifficultyService.Add(target);

            Models.DTO.WalkDifficulty walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(target);

            return CreatedAtAction(nameof(Add), walkDifficultyDTO);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        [ActionName("Update")]
        [Authorize(Roles = "Write")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMethod.WalkDifficulty walkDifficulty)
        {
            WalkDifficulty target = _mapper.Map<WalkDifficulty>(walkDifficulty);
            target = await _walkDifficultyService.Update(id, target);

            if (target == null)
            {
                return NotFound();
            }
            Models.DTO.WalkDifficulty walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(target);
            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ActionName("Delete")]
        [Authorize(Roles = "Write")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            WalkDifficulty walkDifficulty = await _walkDifficultyService.Delete(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            return Ok(walkDifficulty);
        }

    }
}
