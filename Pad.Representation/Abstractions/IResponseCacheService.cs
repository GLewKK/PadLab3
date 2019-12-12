using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pad.Representation.Abstractions
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeTimeLive);

        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}
