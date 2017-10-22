namespace Microsoft.Extensions.Caching.Memory
{
    using Cacheable;

    public static class CacheEntryOptionsExtensions
    {
        public static MemoryCacheEntryOptions GetMemoryCacheOptions(this ICacheableRequest request)
        {
            return new MemoryCacheEntryAdapter().Convert(request.GetCacheOptions());
        }
    }
}