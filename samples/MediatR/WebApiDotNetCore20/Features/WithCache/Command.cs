namespace WebApiDotNetCore20.Features.WithCache
{
    using System;
    using Cacheable;
    using MediatR;
    using Models;

    public class Command : IRequest<Result>, ICacheableRequest
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