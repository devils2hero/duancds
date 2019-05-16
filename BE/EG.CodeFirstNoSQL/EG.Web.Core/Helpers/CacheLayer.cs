using Microsoft.Extensions.Caching.Memory;
using System;

namespace EG.Web.Core.Helpers
{
    public class CacheLayer
    {
        private static CacheLayer instance = null;
        private static IMemoryCache _MemoryCache = new MemoryCache(new MemoryCacheOptions());
        public static T GetCache<T>(string Key)
        {
            return _MemoryCache.Get<T>(Key);
        }
        public static object GetCache(string Key)
        {
            return _MemoryCache.Get(Key);
        }
        public static T SetCache<T>(string Key, T Value, DateTime Expried)
        {
            return _MemoryCache.Set<T>(Key, Value, Expried);
        }
        public static string SetCache(string Key, string Value, DateTime Expried)
        {
            return _MemoryCache.Set(Key, Value, Expried);
        }
        public static bool RemoveCache(string Key)
        {
            try
            {
                _MemoryCache.Remove(Key);
                return true;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.ToString());
            }
        }
        
    }
}
