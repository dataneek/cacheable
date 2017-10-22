namespace WebApiDotNetCore20.Models
{
    using System;

    public class Result
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public DateTimeOffset Created { get; } = DateTimeOffset.Now;
    }
}