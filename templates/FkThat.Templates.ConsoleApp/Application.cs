using System.CommandLine;

namespace FkThat.Templates.ConsoleApp;

/// <inheritdoc/>
public class Application : IApplication
{
    private readonly RootCommand _helloCmd;

    /// <summary>
    /// Initializes a new instance of the <see cref="Application"/> class.
    /// </summary>
    public Application(ICommandFactory commandFactory)
    {
        Option<string> whoOption = new(new[] { "--who", "-w" }, () => "World");

        _helloCmd = new RootCommand();
        _helloCmd.AddOption(whoOption);

        _helloCmd.SetHandler(async (context) => {
            var cmd = commandFactory.CreateCommand<ICommand<string>, HelloCmd>();
            var who = context.ParseResult.GetValueForOption(whoOption) ?? "";
            var cancellationToken = context.GetCancellationToken();
            await cmd.ExecAsync(who, cancellationToken);
        });
    }

    /// <inheritdoc/>
    public async Task RunAsync(string[] args)
    {
        await _helloCmd.InvokeAsync(args);
    }
}
