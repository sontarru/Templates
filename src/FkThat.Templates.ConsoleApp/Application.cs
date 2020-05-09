using System.CommandLine;

namespace FkThat.Templates.ConsoleApp;

/// <inheritdoc/>
public class Application : IApplication
{
    private readonly ICommandFactory _commandFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="Application"/> class.
    /// </summary>
    public Application(ICommandFactory commandFactory)
    {
        _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(commandFactory));
   }

    /// <inheritdoc/>
    public async Task RunAsync(string[] args)
    {
        _ = args ?? throw new ArgumentNullException(nameof(args));

        Option<string> whoOption = new(new[] { "--who", "-w" }, () => "World");

        var _helloCmd = new RootCommand();
        _helloCmd.AddOption(whoOption);

        _helloCmd.SetHandler(async (context) =>
        {
            var cmd = _commandFactory.CreateCommand<ICommand<string>, HelloCmd>();
            var who = context.ParseResult.GetValueForOption(whoOption)!;
            var cancellationToken = context.GetCancellationToken();
            await cmd.ExecAsync(who, cancellationToken).ConfigureAwait(false);
        });

        await _helloCmd.InvokeAsync(args).ConfigureAwait(false);
    }
}
