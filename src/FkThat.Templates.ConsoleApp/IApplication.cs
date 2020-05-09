namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// Main application class.
/// </summary>
public interface IApplication
{
    /// <summary>
    /// Runs the application.
    /// </summary>
    /// <param name="args">The CLI arguments.</param>
    Task RunAsync(string[] args);
}
