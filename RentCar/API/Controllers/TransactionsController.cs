using BLL.DTOs.Transactions;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionResponse>> Get()
        {
            return Ok(transactionService.GetAll());
        }

        [HttpGet("GetAllActive")]
        public ActionResult<IEnumerable<TransactionResponse>> GetAllActive()
        {
            return Ok(transactionService.GetAllActive());
        }

        [HttpGet("{id}")]
        public ActionResult<TransactionResponse> Get(int id)
        {
            return Ok(transactionService.Get(id));
        }

        [HttpPost]
        public ActionResult<TransactionResponse> Post([FromBody] CreateTransactionRequest request)
        {
            return Ok(transactionService.Add(request));
        }

        [HttpPost("{vehicleId}")]
        public ActionResult<TransactionResponse> Post(int vehicleId)
        {
            return Ok(transactionService.CompleteTransaction(vehicleId));
        }

        [HttpPut("{id}")]
        public ActionResult<TransactionResponse> Put(int id, [FromBody] CreateTransactionRequest request)
        {
            return Ok(transactionService.Update(id, request));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            transactionService.Delete(id);
            return Ok();
        }
    }
}
