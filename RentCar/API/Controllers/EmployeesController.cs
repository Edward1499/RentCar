using BLL.DTOs.Clients;
using BLL.DTOs.Employees;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeResponse>> Get()
        {
            return Ok(employeeService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<EmployeeResponse>> GetAllActive()
        {
            return Ok(employeeService.GetAllActive());
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeResponse> Get(int id)
        {
            return Ok(employeeService.Get(id));
        }

        [HttpPost]
        public ActionResult<EmployeeResponse> Post([FromBody] CreateEmployeeRequest request)
        {
            return Ok(employeeService.Add(request));
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeResponse> Put(int id, [FromBody] CreateEmployeeRequest request)
        {
            return Ok(employeeService.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            employeeService.Delete(id);
            return Ok();
        }
    }
}
