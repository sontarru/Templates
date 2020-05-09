namespace FkThat.Templates.ConsoleApp;

public class Test_HelloCmd
{
    [Fact]
    public async Task ExecAsync_should_check_null_who()
    {
        string who = null!;
        HelloCmd sut = new();

        await sut.Invoking(s => s.ExecAsync(who, default))
            .Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(who));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task ExecAsync_should_check_blank_who(string who)
    {
        StringWriter stdout = new();
        Console.SetOut(stdout);
        HelloCmd sut = new();

        await sut.Invoking(s => s.ExecAsync(who, default))
            .Should().ThrowAsync<ArgumentException>()
            .WithParameterName(nameof(who));
    }

    [Fact]
    public async Task ExecAsync_should_say_hello()
    {
        StringWriter stdout = new();
        Console.SetOut(stdout);
        HelloCmd sut = new();
        await sut.ExecAsync("World", default).ConfigureAwait(false);
        stdout.ToString().Should().Be($"Hello, World!{Environment.NewLine}");
    }
}
