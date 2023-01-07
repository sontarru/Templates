namespace FkThat.Templates.ConsoleApp;

public class Test_Application
{
    [Fact]
    public async Task RunAsync_should_handle_long_option()
    {
        var commandFactory = A.Fake<ICommandFactory>();
        var helloCommand = A.Fake<ICommand<string>>();

        A.CallTo(() => commandFactory.CreateCommand<ICommand<string>, HelloCmd>())
            .Returns(helloCommand);

        Application sut = new(commandFactory);
        await sut.RunAsync(new[] { "--who", "World" }).ConfigureAwait(false);

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .MustHaveHappened();
    }

    [Fact]
    public async Task RunAsync_should_handle_short_option()
    {
        var commandFactory = A.Fake<ICommandFactory>();
        var helloCommand = A.Fake<ICommand<string>>();

        A.CallTo(() => commandFactory.CreateCommand<ICommand<string>, HelloCmd>())
            .Returns(helloCommand);

        Application sut = new(commandFactory);
        await sut.RunAsync(new[] { "-w", "World" }).ConfigureAwait(false);

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .MustHaveHappened();
    }

    [Fact]
    public async Task RunAsync_should_handle_default_option()
    {
        var commandFactory = A.Fake<ICommandFactory>();
        var helloCommand = A.Fake<ICommand<string>>();

        A.CallTo(() => commandFactory.CreateCommand<ICommand<string>, HelloCmd>())
            .Returns(helloCommand);

        Application sut = new(commandFactory);
        await sut.RunAsync(new string[] { }).ConfigureAwait(false);

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .MustHaveHappened();
    }
}
