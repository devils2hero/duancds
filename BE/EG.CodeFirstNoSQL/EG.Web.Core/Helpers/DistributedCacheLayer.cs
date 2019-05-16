using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EG.Web.Core.Helpers
{
    public interface IDistributedCacheLayer
    {
        string GetCache(string Key);
        Task<string> GetCacheAsync(string Key);
        void SetCache(string Key, string Values, TimeSpan Expried);
        Task SetCacheAsync(string Key, string Values, TimeSpan Expried);
        Task RemoveCache(string Key);
    }
    public class DistributedCacheLayer : IDistributedCacheLayer
    {
        private readonly IDistributedCache _cache;
        public DistributedCacheLayer(IDistributedCache _cache)
        {
            this._cache = _cache;
        }
        public string GetCache(string Key)
        {
            return _cache.GetString(Key);
        }
        public async Task<string> GetCacheAsync(string Key)
        {
            var value = await _cache.GetAsync(Key);
            return Encoding.UTF8.GetString(value);
        }
        public void SetCache(string Key, string Values, TimeSpan Expried)
        {
            //_cache.Set(Key, System.Text.Encoding.UTF8.GetBytes(Values), new DistributedCacheEntryOptions().SetAbsoluteExpiration(Expried));
            _cache.Set(Key, System.Text.Encoding.UTF8.GetBytes(Values));
        }
        public async Task SetCacheAsync(string Key, string Values, TimeSpan Expried)
        {
            //await _cache.SetAsync(Key, System.Text.Encoding.UTF8.GetBytes(Values), new DistributedCacheEntryOptions().SetAbsoluteExpiration(Expried));
            await _cache.SetAsync(Key, System.Text.Encoding.UTF8.GetBytes(Values));
        }
        public async Task RemoveCache(string Key)
        {
            await _cache.RemoveAsync(Key);
        }
    }
    public static class StartTimeHeaderExtensions
    {
        public static IApplicationBuilder UseStartTimeHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DistributedCacheLayer>();
        }
    }
}
