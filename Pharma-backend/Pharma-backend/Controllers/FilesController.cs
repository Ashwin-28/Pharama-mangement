using Microsoft.AspNetCore.Mvc;

namespace Pharma_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPrescription(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var fileName = await _fileService.SavePrescriptionAsync(file);
            return Ok(new { FileName = fileName });
        }
    }
}
