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
            return Ok(_mapper.Map<List<Models.DTO.Walk>>(walks));
        }

        [HttpGet]
        [Route("Get/{id:guid}")]
        [ActionName("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var walk = await _walkService.Get(id);
            if(walk == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Models.DTO.Walk>(walk));
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] Models.DTO.AddMethod.Walk walk)
        {
            var newWalk = _mapper.Map<Walk>(walk);
            newWalk = await _walkService.Add(newWalk);

            return CreatedAtAction(nameof(Get), _mapper.Map<Models.DTO.Walk>(newWalk));
        }
    }
}
