using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace FkThat.Templates.Cli
{
    public class Test_ConsoleAdapter
    {
        [Fact]
        public void StdOut_ShouldReturnStandardOutput()
        {
            var sut = new ConsoleAdapter();
            sut.StdOut.Should().Be(System.Console.Out);
        }

        [Fact]
        public void StdIn_ShouldReturnStandardInput()
        {
            var sut = new ConsoleAdapter();
            sut.StdIn.Should().Be(System.Console.In);
        }

        [Fact]
        public void StdErr_ShouldReturnStandardError()
        {
            var sut = new ConsoleAdapter();
            sut.StdErr.Should().Be(System.Console.Error);
        }
    }
}
