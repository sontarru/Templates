using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;

namespace FkThat.Templates.Quartz
{
    public class Test_HelloJob
    {
        [Fact]
        public async Task Execute_ShouldLogMessage()
        {
            var logger = A.Fake<ILogger<HelloJob>>();
            var sut = new HelloJob(logger);
            await sut.Execute(null);

            A.CallTo(logger).Where(c => c.Method.Name == nameof(ILogger.Log))
                .WithVoidReturnType().WhenArgumentsMatch(args =>
                    (LogLevel)args[0] == LogLevel.Information &&
                    args[2].ToString() == "Hello, World!")
                .MustHaveHappened();
        }
    }
}
