namespace WebApiDotNetCore20.Models
{
    using System.Threading;
    using Humanizer;

    public class ResultBuilder : IResultBuilder
    {
        public Result GetResult(int number)
        {
            Thread.Sleep(5000); //# this thing is expensive :(

            var result = new Result
            {
                Number = number,
                Text = number.ToWords(),
            };

            return result;
        }
    }
}