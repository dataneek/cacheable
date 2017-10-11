namespace Cacheable
{
    using System;

    public static class CacheEntryExtensions
    {
        public static CacheEntryOptions SetAbsoluteExpiration(this CacheEntryOptions options, TimeSpan relative)
        {
            options.AbsoluteExpirationRelativeToNow = relative;
            return options;
        }

        public static CacheEntryOptions SetAbsoluteExpiration(this CacheEntryOptions options, DateTimeOffset absolute)
        {
            options.AbsoluteExpiration = absolute;
            return options;
        }

        public static CacheEntryOptions SetSlidingExpiration(this CacheEntryOptions options, TimeSpan offset)
        {
            options.SlidingExpiration = offset;
            return options;
        }
    }
}