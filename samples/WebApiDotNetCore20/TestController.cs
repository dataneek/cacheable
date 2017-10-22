namespace WebApiDotNetCore20
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;

    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IMediator mediator;

        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Benchmark, HttpGet("with-cache/{number}")]
        public async Task<IActionResult> GetWithCache(int number)
        {
            var result =
                await mediator.Send(new Command { Number = number });

            return Ok(result);
        }

        [Benchmark, HttpGet("without-cache/{number}")]
        public async Task<IActionResult> GetwithNoCache(int number)
        {
            var result =
                await mediator.Send(new Command { Number = number, IsCacheable = false });

            return Ok(result);
        }
    }
}