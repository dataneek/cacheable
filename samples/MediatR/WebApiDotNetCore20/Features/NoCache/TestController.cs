namespace WebApiDotNetCore20.Features.NoCache
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SimpleMeasure;
    using MediatR;

    [Route("api/no-cache")]
    public class TestController : Controller
    {
        private readonly IMediator mediator;

        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Benchmark, HttpGet("{number}")]
        public async Task<IActionResult> Get(int number)
        {
            var result =
                await mediator.Send(new Command { Number = number });

            return Ok(result);
        }
    }
}