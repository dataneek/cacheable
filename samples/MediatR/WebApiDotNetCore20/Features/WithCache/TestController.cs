namespace WebApiDotNetCore20.Features.WithCache
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;

    [Route("api/with-cache")]
    public class TestController : Controller
    {
        private readonly IMediator mediator;

        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Benchmark, HttpGet("{number}")]
        public async Task<IActionResult> Get(int number, bool isCacheable)
        {
            var result =
                await mediator.Send(new Command { Number = number, IsCacheable = isCacheable });

            return Ok(result);
        }
    }
}