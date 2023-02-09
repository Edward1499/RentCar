using BLL.DTOs.Fuels;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        private readonly IFuelService fuelService;

        public FuelsController(IFuelService fuelService)
        {
            this.fuelService = fuelService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FuelResponse>> Get()
        {
            return Ok(fuelService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<FuelResponse>> GetAllActive()
        {
            return Ok(fuelService.GetAllActive());
        }

        [HttpGet("{id}")]
        public ActionResult<FuelResponse> Get(int id)
        {
            return Ok(fuelService.Get(id));
        }

        [HttpPost]
        public ActionResult<FuelResponse> Post([FromBody] CreateFuelRequest request)
        {
            return Ok(fuelService.Add(request));
        }

        [HttpPut("{id}")]
        public ActionResult<FuelResponse> Put(int id, [FromBody] CreateFuelRequest request)
        {
            return Ok(fuelService.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            fuelService.Delete(id);
            return Ok();
        }
    }
}
