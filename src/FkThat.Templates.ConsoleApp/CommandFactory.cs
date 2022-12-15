using Microsoft.Extensions.DependencyInjection;

namespace FkThat.Templates.ConsoleApp;

/// <inheritdoc/>
public class CommandFactory : ICommandFactory
{
    private readonly IServiceProvider _sp;

    /// <summary>
    /// Initialize a new instance of <c cref="CommandFactory"/>.
    /// </summary>
    /// <param name="sp">The service provider.</param>
    public CommandFactory(IServiceProvider sp)
    {
        _sp = sp;
    }

    /// <inheritdoc/>
    public TCommandInterface CreateCommand<TCommandInterface, TCommand>()
        where TCommand : class, TCommandInterface => _sp.GetRequiredService<TCommand>();
}
