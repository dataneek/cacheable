namespace WebApiDotNetCore20
{
    using System;
    using Cacheable;
    using MediatR;

    public class Command : IRequest<CommandResult>, ICacheableRequest
    {
        public int Number { get; set; }

        public bool IsCacheable { get; set; } = true;

        public string GetCacheKey() { return "number:" + Number; }

        public CacheEntryOptions GetCacheOptions()
        {
            return new CacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(5) };
        }
    }
}