namespace Microsoft.Extensions.Caching.Memory
{
    using System.Threading.Tasks;
    using Cacheable;
    using MediatR;

    public abstract class MemoryCacheAsyncRequestHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> innerHandler;
        private readonly IMemoryCache cache;

        public MemoryCacheAsyncRequestHandler(IAsyncRequestHandler<TRequest, TResponse> innerHandler, IMemoryCache cache)
        {
            this.innerHandler = innerHandler;
            this.cache = cache;
        }

        Task<TResponse> IAsyncRequestHandler<TRequest, TResponse>.Handle(TRequest message)
        {
            var cacheableRequest = message as ICacheableRequest;

            if (cacheableRequest != null && cacheableRequest.IsCacheable)
            {
                var cacheKey = cacheableRequest.GetCacheKey();

                return cache.GetOrCreateAsync(cacheKey, entry =>
                {
                    entry.SetOptions(cacheableRequest.GetMemoryCacheOptions());

                    return innerHandler.Handle(message);
                });
            }

            return innerHandler.Handle(message);
        }
    }
}