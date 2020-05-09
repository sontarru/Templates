using System.Diagnostics.CodeAnalysis;

namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// Hello world.
/// </summary>
public class HelloCmd : ICommand<string>
{
    /// <inheritdoc/>
    [SuppressMessage("Naming", "CA1725:Parameter names should match base declaration")]
    public async Task ExecAsync(string who, CancellationToken cancellationToken)
    {
        _ = who ?? throw new ArgumentNullException(nameof(who));

        if (string.IsNullOrWhiteSpace(who))
        {
            throw new ArgumentException($"{nameof(who)} must not be blank.", nameof(who));
        }

        await Console.Out.WriteLineAsync($"Hello, {who}!").ConfigureAwait(false);
    }
}
