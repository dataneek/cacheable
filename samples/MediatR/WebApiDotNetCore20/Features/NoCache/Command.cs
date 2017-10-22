namespace WebApiDotNetCore20.Features.NoCache
{
    using MediatR;
    using Models;

    public class Command : IRequest<Result>
    {
        public int Number { get; set; }
    }
}