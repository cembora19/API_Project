using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController:ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            if (file is null || file.Length == 0)
                return BadRequest("A non-empty file is required.");

            var originalFileName = Path.GetFileName(file.FileName);
            if (string.IsNullOrWhiteSpace(originalFileName))
                return BadRequest("The file name is invalid.");

            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            Directory.CreateDirectory(folder);

            var storedFileName = $"{Guid.NewGuid():N}{Path.GetExtension(originalFileName)}";
            var path = Path.Combine(folder, storedFileName);
            await using var stream = new FileStream(path, FileMode.CreateNew);
            await file.CopyToAsync(stream, cancellationToken);

            return Ok(new
            {
                fileName = storedFileName,
                originalFileName,
                size = file.Length
            });
        }

        [HttpGet("download")]
        public async Task<IActionResult> Download(string fileName, CancellationToken cancellationToken)
        {
            var safeFileName = Path.GetFileName(fileName);
            if (string.IsNullOrWhiteSpace(safeFileName) || safeFileName != fileName)
                return BadRequest("The file name is invalid.");

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", safeFileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(safeFileName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath, cancellationToken);
            return File(bytes, contentType, safeFileName);
        }
    }
}
