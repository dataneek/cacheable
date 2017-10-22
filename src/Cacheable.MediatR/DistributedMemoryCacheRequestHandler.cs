namespace Microsoft.Extensions.Caching.Distributed
{
    using System;
    using Cacheable;
    using MediatR;

    public abstract class DistributedMemoryCacheRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> innerHandler;
        private readonly IDistributedCache cache;

        public DistributedMemoryCacheRequestHandler(IRequestHandler<TRequest, TResponse> innerHandler, IDistributedCache cache)
        {
            this.innerHandler = innerHandler;
            this.cache = cache;
        }

        TResponse IRequestHandler<TRequest, TResponse>.Handle(TRequest message)
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