using BackendDotnetData.Repositories;
using BackendDotnetModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendDotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehiclesController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            return Ok(await _vehicleRepository.GetAllVehicles());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleDetails(int id)
        {
            return Ok(await _vehicleRepository.GetVehicleDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _vehicleRepository.InsertVehicle(vehicle);
            return Created("created", created);
        }
    }
}
