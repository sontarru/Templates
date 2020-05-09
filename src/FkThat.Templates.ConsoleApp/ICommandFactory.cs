namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// The factory of commands.
/// </summary>
public interface ICommandFactory
{
    /// <summary>
    /// Creates the command of the type <typeparamref name="TCommand"/>.
    /// </summary>
    /// <typeparam name="TCommandInterface">The type of the command interface.</typeparam>
    /// <typeparam name="TCommand">The type of the command implementation.</typeparam>
    /// <returns></returns>
    TCommandInterface CreateCommand<TCommandInterface, TCommand>()
        where TCommand : class, TCommandInterface;
}
