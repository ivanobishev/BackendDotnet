using BackendDotnetData.Repositories;
using BackendDotnetModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            return Ok(await _ownerRepository.GetAllOwners());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            return Ok(await _ownerRepository.GetOwnerDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            if (owner == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _ownerRepository.InsertOwner(owner);
            return Created("created", created);
        }
    }
}
