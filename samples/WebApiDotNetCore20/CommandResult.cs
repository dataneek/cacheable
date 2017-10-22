namespace WebApiDotNetCore20
{
    using System;

    public class CommandResult
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Created { get; } = DateTimeOffset.Now;
    }
}