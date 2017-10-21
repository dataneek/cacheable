namespace Microsoft.Extensions.Caching.Distributed
{
    using System;
    using System.Threading.Tasks;
    using Cacheable;
    using MediatR;

    public abstract class DistributedMemoryCacheAsyncRequestHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IAsyncRequestHandler<TRequest, TResponse> innerHandler;
        private readonly IDistributedCache cache;

        public DistributedMemoryCacheAsyncRequestHandler(IAsyncRequestHandler<TRequest, TResponse> innerHandler, IDistributedCache cache)
        {
            this.innerHandler = innerHandler;
            this.cache = cache;
        }

        Task<TResponse> IAsyncRequestHandler<TRequest, TResponse>.Handle(TRequest message)
        {
            var cacheableRequest = message as ICacheableRequest;

            //if (cacheableRequest != null && cacheableRequest.IsCacheable)
            //{
            //    var cacheKey = cacheableRequest.GetCacheKey();
            //}

            //throw new NotImplementedException();

            return innerHandler.Handle(message);
        }
    }
}