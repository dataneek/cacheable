namespace WebApiDotNetCore20
{
    using System.Threading;
    using Humanizer;
    using MediatR;

    public class CommandHandler : IRequestHandler<Command, CommandResult>
    {
        CommandResult IRequestHandler<Command, CommandResult>.Handle(Command message)
        {
            Thread.Sleep(5000); //# this is expensive :(

            var result = new CommandResult
            {
                Number = message.Number,
                Text = message.Number.ToWords(),
            };

            return result;
        }
    }
}