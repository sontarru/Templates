namespace FkThat.Templates.Cli;

public interface IApplication
{
    Task RunAsync(IEnumerable<string> args, CancellationToken cancellationToken);
}
