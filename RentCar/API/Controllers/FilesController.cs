using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public FilesController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public ActionResult Post([FromForm]IFormFile file)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(_environment.WebRootPath + "\\Images"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\Images\\");
                }

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" + file.FileName;
                string filePath = _environment.WebRootPath + "\\Images\\" + fileName;

                using (FileStream filestream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(filestream);
                    filestream.Flush();
                    return Ok($"https://localhost:7110/images/{fileName}");
                }
            }

            return BadRequest();
        }
    }
}
