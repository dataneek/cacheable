namespace WebApiDotNetCore20.Features.NoCache
{
    using System.Threading.Tasks;
    using MediatR;
    using Models;

    public class CommandHandler : IAsyncRequestHandler<Command, Result>
    {
        private readonly IResultBuilder resultBuilder;

        public CommandHandler(IResultBuilder resultBuilder)
        {
            this.resultBuilder = resultBuilder;
        }

        Task<Result> IAsyncRequestHandler<Command, Result>.Handle(Command message)
        {
            return Task.FromResult(resultBuilder.GetResult(message.Number));
        }
    }
}