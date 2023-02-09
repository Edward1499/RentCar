using BLL.DTOs.Clients;
using BLL.DTOs.Inspections;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionsController : ControllerBase
    {
        private readonly IInspectionService inspectionService;

        public InspectionsController(IInspectionService inspectionService)
        {
            this.inspectionService = inspectionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InspectionResponse>> Get()
        {
            return Ok(inspectionService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<InspectionResponse>> GetAllActive()
        {
            return Ok(inspectionService.GetAllActive());
        }

        [HttpGet("{id}")]
        public ActionResult<InspectionResponse> Get(int id)
        {
            return Ok(inspectionService.Get(id));
        }

        [HttpPost]
        public ActionResult<InspectionResponse> Post([FromBody] CreateInspectionRequest request)
        {
            return Ok(inspectionService.Add(request));
        }

        [HttpPut("{id}")]
        public ActionResult<InspectionResponse> Put(int id, [FromBody] CreateInspectionRequest request)
        {
            return Ok(inspectionService.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            inspectionService.Delete(id);
            return Ok();
        }
    }
}
