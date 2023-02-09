using API.Utilities;
using BLL.DTOs.Clients;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientResponse>> Get()
        {
            return Ok(clientService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<ClientResponse>> GetAllActive()
        {
            return Ok(clientService.GetAllActive());
        }

        [HttpGet("{id}")]
        public ActionResult<ClientResponse> Get(int id)
        {
            return Ok(clientService.Get(id));
        }

        [HttpGet("validate-number/{personalNumber}")]
        public ActionResult<bool> ValidatePersonalNumber(string personalNumber)
        {
            return Ok(PersonalNumberValidation.IsValidIdNumber(personalNumber));
        }

        [HttpPost]
        public ActionResult<ClientResponse> Post([FromBody] CreateClientRequest request)
        {
            return Ok(clientService.Add(request));
        }

        [HttpPut("{id}")]
        public ActionResult<ClientResponse> Put(int id, [FromBody] CreateClientRequest request)
        {
            return Ok(clientService.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            clientService.Delete(id);
            return Ok();
        }
    }
}
