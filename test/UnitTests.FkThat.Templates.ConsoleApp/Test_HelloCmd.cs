using FkThat.Gists;

namespace FkThat.Templates.ConsoleApp;

public class Test_HelloCmd
{
    [Fact]
    public void Ctor_should_check_null_console()
    {
        ISystemConsole console = null!;
        FluentActions.Invoking(() => new HelloCmd(console))
            .Should().Throw<ArgumentNullException>()
            .Which.ParamName.Should().Be(nameof(console));
    }

    [Fact]
    public async Task ExecAsync_should_check_null_who()
    {
        string who = null!;
        HelloCmd sut = new(A.Fake<ISystemConsole>());

        await sut.Invoking(s => s.ExecAsync(who, default))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(who));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ExecAsync_should_check_blank_who(string who)
    {
        var console = A.Fake<ISystemConsole>();
        StringWriter stdout = new();
        A.CallTo(() => console.Out).Returns(stdout);
        HelloCmd sut = new(console);

        await sut.Invoking(s => s.ExecAsync(who, default))
            .Should().ThrowAsync<ArgumentException>()
            .WithParameterName(nameof(who));
    }

    [Fact]
    public async Task ExecAsync_should_say_hello()
    {
        var console = A.Fake<ISystemConsole>();
        StringWriter stdout = new();
        A.CallTo(() => console.Out).Returns(stdout);
        HelloCmd sut = new(console);
        await sut.ExecAsync("World", default).ConfigureAwait(false);
        stdout.ToString().Should().Be($"Hello, World!{Environment.NewLine}");
    }
}
