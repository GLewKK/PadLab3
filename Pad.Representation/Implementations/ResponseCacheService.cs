using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Pad.Representation.Abstractions;
using Newtonsoft.Json;

namespace Pad.Representation.Implementations
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public ResponseCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive)
        {
            if (response is null)
            {
                return;
            }

            var seriakizedResponse = JsonConvert.SerializeObject(response);

            await _distributedCache.SetStringAsync(cacheKey, seriakizedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeTimeLive
            });
        }

        public async Task<string> GetCacheResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);

            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }
    }
}
