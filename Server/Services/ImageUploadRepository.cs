using System;
using System.IO;
using System.Threading.Tasks;
using Medieval.Server.Data;
using Medieval.Shared;
using Microsoft.Extensions.Logging;
using Server.Services.Interfaces;

namespace Server.Services
{
public class ImageUploadRepository : BaseRepository, IImageUploadRepository
    {
        public ImageUploadRepository(MedievalContext context, ILogger<BaseRepository> logger) : base (context, logger)
        { }

        public async Task<bool> SaveImages(ImageUploadModel imageUpload)
        {
            foreach (var image in imageUpload.Images)
            {
                var path = @"E:\Test\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                        
                string fileExtenstion = image.FileType.ToLower().Contains("png") ? "png" : "jpg";
                string fileName = Path.Combine(path, $"{Guid.NewGuid()}.{fileExtenstion}");
                using(var fileStream = System.IO.File.Create(fileName))
                {
                    await fileStream.WriteAsync(image.Data);
                }
            }
            _logger.LogInformation($"Saved {imageUpload.Images.Count} images to the server.");
            return true;
        }
    }
}