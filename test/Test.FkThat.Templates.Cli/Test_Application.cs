using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace FkThat.Templates.Cli
{
    public class Test_Application
    {
        [Fact]
        public async Task RunAsync_ShouldSayHello()
        {
            using var txtWriter = new StringWriter();
            var console = A.Fake<IConsole>();
            A.CallTo(() => console.StdOut).Returns(txtWriter);
            var sut = new Application(console);
            await sut.RunAsync(Array.Empty<string>(), CancellationToken.None);
            txtWriter.ToString().Should().Be("Hello, world!" + Environment.NewLine);
        }
    }
}
