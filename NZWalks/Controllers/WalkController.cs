using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models;
using NZWalks.Services.IServices;
using System.Runtime.InteropServices;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("Walks")]
    public class WalkController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWalkService _walkService;

        public WalkController(IMapper mapper, IWalkService walkService)
        {
            this._mapper = mapper;
            this._walkService = walkService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var walks = await _walkService.GetAll();
            List<Models.DTO.Walk> walksDTO = _mapper.Map<List<Models.DTO.Walk>>(walks);
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
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
        public async Task<IActionResult> Add([FromBody] Models.DTO.AddMethod.Walk walk)
        {
            Walk newWalk = _mapper.Map<Walk>(walk);
            newWalk = await _walkService.Add(newWalk);

            Models.DTO.Walk walkDTO = _mapper.Map<Models.DTO.Walk>(newWalk);

            return CreatedAtAction(nameof(Get), walkDTO);
        }

        [HttpPatch]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMethod.Walk walk)
        {
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
        public bool IsValid(Models.DTO.AddMethod.Walk walk)
        {
            bool valid = true;

            return valid;
        }
        #endregion
    }
}
