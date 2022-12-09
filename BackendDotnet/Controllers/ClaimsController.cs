using BackendDotnetData.Repositories;
using BackendDotnetModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;
        public ClaimsController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClaims()
        {
            return Ok(await _claimRepository.GetAllClaims());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            return Ok(await _claimRepository.GetClaimDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateClaim([FromBody] Claim claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _claimRepository.InsertClaim(claim);
            return Created("created", created);
        }
    }
}
