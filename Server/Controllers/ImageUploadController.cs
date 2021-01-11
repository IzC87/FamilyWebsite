using System;
using System.IO;
using System.Threading.Tasks;
using Medieval.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services.Interfaces;

namespace Medieval.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class ImageUploadController : ControllerBase
    {
        private readonly ILogger<ImageUploadController> _logger;
        private readonly IImageUploadRepository _imageUploadRepository;

        public ImageUploadController(ILogger<ImageUploadController> logger, IImageUploadRepository imageUploadRepository)
        {
            _logger = logger;
            _imageUploadRepository = imageUploadRepository;
        }
        
        [HttpPost]
        [Route("saveimage")]
        public async Task<IActionResult> SaveImages([FromBody] ImageUploadModel imageUpload)
        {
            try
            {
                var result = await _imageUploadRepository.SaveImages(imageUpload);
                if (result)
                    return Ok();
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                // return this.StatusCode(StatusCodes.Status500InternalServerError, $"database failure {e.Message}");
                _logger.LogError($"Unable to save one or more files, exception: {e.Message}");
                return BadRequest();
            }

        }
    }
}