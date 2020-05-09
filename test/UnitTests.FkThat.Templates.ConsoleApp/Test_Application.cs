namespace FkThat.Templates.ConsoleApp;

public class Test_Application
{
    [Fact]
    public void Ctor_should_check_null_commandFactory()
    {
        ICommandFactory commandFactory = null!;
        FluentActions.Invoking(() => new Application(commandFactory)).Should()
            .Throw<ArgumentNullException>().WithParameterName(nameof(commandFactory));
    }

    [Fact]
    public async Task RunAsync_should_check_null_args()
    {
        var commandFactory = A.Fake<ICommandFactory>();
        string[] args = null!;
        Application sut = new(commandFactory);

        await sut.Invoking(s => s.RunAsync(args)).Should()
            .ThrowAsync<ArgumentNullException>().WithParameterName(nameof(args));
    }

    [Fact]
    public async Task RunAsync_should_handle_long_option()
    {
        var commandFactory = A.Fake<ICommandFactory>();
        var helloCommand = A.Fake<ICommand<string>>();

        A.CallTo(() => commandFactory.CreateCommand<ICommand<string>, HelloCmd>())
            .Returns(helloCommand);

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .Returns(Task.CompletedTask);

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

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .Returns(Task.CompletedTask);

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

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .Returns(Task.CompletedTask);

        Application sut = new(commandFactory);
        await sut.RunAsync(new string[] { }).ConfigureAwait(false);

        A.CallTo(() => helloCommand.ExecAsync("World", A<CancellationToken>._))
            .MustHaveHappened();
    }
}
