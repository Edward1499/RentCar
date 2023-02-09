using BLL.DTOs.Reports;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpPost]
        public async Task<ActionResult> Generate(ReportDTO request)
        {
            return Ok(await reportService.Generate(request, Directory.GetCurrentDirectory()));
        }
    }
}
