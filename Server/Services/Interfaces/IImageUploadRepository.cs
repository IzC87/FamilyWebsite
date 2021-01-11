using System.Threading.Tasks;
using Medieval.Shared;

namespace Server.Services.Interfaces
{
    public interface IImageUploadRepository : IBaseRepository
    {
        Task<bool> SaveImages(ImageUploadModel imageUpload);
    }
}