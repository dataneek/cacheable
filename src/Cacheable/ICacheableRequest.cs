namespace Cacheable
{
    public interface ICacheableRequest : ICacheable
    {
        string GetCacheKey();
        CacheEntryOptions GetCacheOptions();
    }
}