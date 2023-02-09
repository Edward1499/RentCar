using Azure.Core;
using BLL.DTOs.VehicleTypes;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypesController : ControllerBase
    {
        private readonly IVehicleTypeService vehicleTypeService;

        public VehicleTypesController(IVehicleTypeService vehicleTypeService)
        {
            this.vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleTypeResponse>> Get()
        {
            return Ok(vehicleTypeService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<VehicleTypeResponse>> GetAllActive()
        {
            return Ok(vehicleTypeService.GetAllActive());
        }

        // GET api/<VehicleTypesController>/5
        [HttpGet("{id}")]
        public ActionResult<VehicleTypeResponse> Get(int id)
        {
            return Ok(vehicleTypeService.Get(id));
        }

        // POST api/<VehicleTypesController>
        [HttpPost]
        public ActionResult<VehicleTypeResponse> Post([FromBody] CreateVehicleTypeRequest request)
        {
            return Ok(vehicleTypeService.Add(request));
        }

        // PUT api/<VehicleTypesController>/5
        [HttpPut("{id}")]
        public ActionResult<VehicleTypeResponse> Put(int id, [FromBody] CreateVehicleTypeRequest request)
        {
            return Ok(vehicleTypeService.Update(id, request));
        }

        // DELETE api/<VehicleTypesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            vehicleTypeService.Delete(id);
            return Ok();
        }
    }
}
