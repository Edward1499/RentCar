using BLL.DTOs.Models;
using BLL.DTOs.VehicleTypes;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService modelService;

        public ModelsController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ModelResponse>> Get()
        {
            return Ok(modelService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<ModelResponse>> GetAllActive()
        {
            return Ok(modelService.GetAllActive());
        }

        // GET api/<ModelsController>/5
        [HttpGet("{id}")]
        public ActionResult<ModelResponse> Get(int id)
        {
            return Ok(modelService.Get(id));
        }

        [HttpGet("{brandId}/GetByBrandId")]
        public ActionResult<IEnumerable<ModelResponse>> GetByBrandId(int brandId)
        {
            return Ok(modelService.GetByBrandId(brandId));
        }

        // POST api/<ModelsController>
        [HttpPost]
        public ActionResult<ModelResponse> Post([FromBody] CreateModelRequest request)
        {
            return Ok(modelService.Add(request));
        }

        // PUT api/<ModelsController>/5
        [HttpPut("{id}")]
        public ActionResult<ModelResponse> Put(int id, [FromBody] CreateModelRequest request)
        {
            return Ok(modelService.Update(id, request));
        }

        // DELETE api/<ModelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            modelService.Delete(id);
            return Ok();
        }
    }
}
