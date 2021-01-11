using System.Threading.Tasks;
using Medieval.Server.Data;
using Microsoft.Extensions.Logging;
using Server.Services.Interfaces;

namespace Server.Services
{
public class BaseRepository : IBaseRepository
    {

        protected readonly MedievalContext _medievalContext;
        protected readonly ILogger<BaseRepository> _logger;

        public BaseRepository(MedievalContext context, ILogger<BaseRepository> logger)
        {
            _medievalContext = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _medievalContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _medievalContext.Remove(entity);
        }

        public async Task<bool> Save()
        {
            _logger.LogInformation("Saving changes");
            return (await _medievalContext.SaveChangesAsync()) >= 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating object of type {entity.GetType()}");
            _medievalContext.Update(entity);
        }

    }
}