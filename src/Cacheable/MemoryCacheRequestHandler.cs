namespace Microsoft.Extensions.Caching.Memory
{
    using Cacheable;
    using MediatR;

    public abstract class MemoryCacheRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> innerHandler;
        private readonly IMemoryCache cache;

        public MemoryCacheRequestHandler(IRequestHandler<TRequest, TResponse> innerHandler, IMemoryCache cache)
        {
            this.innerHandler = innerHandler;
            this.cache = cache;
        }

        TResponse IRequestHandler<TRequest, TResponse>.Handle(TRequest message)
        {
            var cacheableRequest = message as ICacheableRequest;

            if (cacheableRequest != null && cacheableRequest.IsCacheable)
            {
                var cacheKey = cacheableRequest.GetCacheKey();

                return cache.GetOrCreate(cacheKey, entry =>
                {
                    entry.SetOptions(cacheableRequest.GetMemoryCacheOptions());

                    return innerHandler.Handle(message);
                });
            }

            return innerHandler.Handle(message);
        }
    }
}