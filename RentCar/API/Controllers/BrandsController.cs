using BLL.DTOs.Brands;
using BLL.DTOs.VehicleTypes;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BrandResponse>> Get()
        {
            return Ok(brandService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<BrandResponse>> GetAllActive()
        {
            return Ok(brandService.GetAllActive());
        }

        // GET api/<Brands>/5
        [HttpGet("{id}")]
        public ActionResult<BrandResponse> Get(int id)
        {
            return Ok(brandService.Get(id));
        }

        // POST api/<Brands>
        [HttpPost]
        public ActionResult<BrandResponse> Post([FromBody] CreateBrandRequest request)
        {
            return Ok(brandService.Add(request));
        }

        // PUT api/<Brand>/5
        [HttpPut("{id}")]
        public ActionResult<BrandResponse> Put(int id, [FromBody] CreateBrandRequest request)
        {
            return Ok(brandService.Update(id, request));
        }

        // DELETE api/<Brand>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            brandService.Delete(id);
            return Ok();
        }
    }
}
