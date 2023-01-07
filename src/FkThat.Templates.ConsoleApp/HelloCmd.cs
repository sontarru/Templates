using System.Diagnostics.CodeAnalysis;

using FkThat.Gists;

namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// Hello world.
/// </summary>
public class HelloCmd : ICommand<string>
{
    private readonly ISystemConsole _console;

    /// <summary>
    /// Initialize <c cref="HelloCmd"/> instance.
    /// </summary>
    public HelloCmd(ISystemConsole console)
    {
        _console = console ?? throw new ArgumentNullException(nameof(console));
    }

    /// <inheritdoc/>
    [SuppressMessage("Naming", "CA1725:Parameter names should match base declaration")]
    public async Task ExecAsync(string who, CancellationToken cancellationToken)
    {
        _ = who ?? throw new ArgumentNullException(nameof(who));

        if (string.IsNullOrWhiteSpace(who))
        {
            throw new ArgumentException($"{nameof(who)} must not be blank.", nameof(who));
        }

        await _console.Out.WriteLineAsync($"Hello, {who}!").ConfigureAwait(false);
    }
}
