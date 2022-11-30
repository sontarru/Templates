namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// Hello world.
/// </summary>
public class HelloCmd : ICommand<string>
{
    /// <inheritdoc/>
    public async Task ExecAsync(string who, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"Hello, {who}!");
    }
}
