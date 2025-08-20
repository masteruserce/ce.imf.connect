using Microsoft.AspNetCore.Mvc;

namespace ce.imf.connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OcrController : ControllerBase
    {
        private readonly string _pythonExe = Path.Combine(Directory.GetCurrentDirectory(), "pythonfiles\\python.exe"); // Or full path to python.exe if needed
        private readonly string _scriptPath = Path.Combine(Directory.GetCurrentDirectory(), "pyScripts\\ocr.py"); // Adjust if needed

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadAndExtract(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                bytes = memoryStream.ToArray();
            }
            // Save file to a temp location
            var tempFile = Path.GetTempFileName();
            try
            {
               // OCR.ReadFile(bytes); // Assuming this method processes the byte array directly
                //using (var stream = System.IO.File.Create(tempFile))
                //{
                //    await file.CopyToAsync(stream);
                //}

                //var invoker = new OcrPythonInvoker(_pythonExe, _scriptPath);
                //List<OcrResult> results = await invoker.ExtractTextAsync(tempFile);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"OCR processing failed: {ex.Message}");
            }
            finally
            {
                if (System.IO.File.Exists(tempFile))
                    System.IO.File.Delete(tempFile);
            }
        }
    }
}