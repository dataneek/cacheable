namespace WebApiDotNetCore20.Features.WithCache
{
    using Cacheable;
    using MediatR;
    using Models;

    public class CommandHandler : IRequestHandler<Command, Result>, ICacheableRequestHandler
    {
        private readonly IResultBuilder resultBuilder;

        public CommandHandler(IResultBuilder resultBuilder)
        {
            this.resultBuilder = resultBuilder;
        }

        Result IRequestHandler<Command, Result>.Handle(Command message)
        {
            return resultBuilder.GetResult(message.Number);
        }
    }
}