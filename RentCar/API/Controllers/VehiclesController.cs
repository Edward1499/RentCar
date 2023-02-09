using BLL.DTOs.Vehicles;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [HttpGet("test")]
        public void Test()
        {
            vehicleService.Test(Directory.GetCurrentDirectory());
        }

        [HttpGet]
        public ActionResult<GetAllVehiclesResponse> Get([FromQuery]GetAllVehiclesParams vehiclesParams)
        {
            return Ok(vehicleService.GetAll(vehiclesParams));
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<VehicleResponse>> GetAllActive()
        {
            return Ok(vehicleService.GetAllActive());
        }

        [HttpGet("{id}")]
        public ActionResult<VehicleResponse> Get(int id)
        {
            return Ok(vehicleService.Get(id));
        }

        [HttpPost]
        public ActionResult<VehicleResponse> Post([FromBody] CreateVehicleRequest request)
        {
            return Ok(vehicleService.Add(request));
        }

        [HttpPut("{id}")]
        public ActionResult<VehicleResponse> Put(int id, [FromBody] CreateVehicleRequest request)
        {
            return Ok(vehicleService.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            vehicleService.Delete(id);
            return Ok();
        }
    }
}
