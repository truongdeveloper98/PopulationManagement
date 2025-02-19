using SWECVI.ApplicationCore.Interfaces;

namespace SWECVI.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
      
        private readonly ICacheProvider _cacheManager;

        private static object _lock = new object();

        public CacheService(ICacheProvider cacheManager)
        {
            _cacheManager = cacheManager;
            
        }

        public void RemoveKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}