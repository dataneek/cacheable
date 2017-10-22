namespace Microsoft.Extensions.Caching.Memory
{
    using Cacheable;

    public class MemoryCacheEntryAdapter
    {
        public MemoryCacheEntryOptions Convert(CacheEntryOptions options)
        {
            return new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = options.AbsoluteExpiration,
                AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
                SlidingExpiration = options.SlidingExpiration,
                Priority = CacheItemPriority.Normal,
            };
        }
    }
}