namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// The factory of commands.
/// </summary>
public interface ICommandFactory
{
    /// <summary>
    /// Creates the command of the type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="I">The type of the command interface.</typeparam>
    /// <typeparam name="T">The type of the command implementation.</typeparam>
    /// <returns></returns>
    I CreateCommand<I, T>() where T : class, I;
}
