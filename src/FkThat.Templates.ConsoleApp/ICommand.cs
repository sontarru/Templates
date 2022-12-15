namespace FkThat.Templates.ConsoleApp;

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(CancellationToken cancellationToken);
}

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand<T>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(T arg, CancellationToken cancellationToken);
}

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand<T0, T1>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(T0 arg0, T1 arg1, CancellationToken cancellationToken);
}

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand<T0, T1, T2>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(T0 arg0, T1 arg1, T2 arg2, CancellationToken cancellationToken);
}

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand<T0, T1, T2, T3>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(T0 arg0, T1 arg1, T2 arg2, T3 arg3, CancellationToken cancellationToken);
}

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand<T0, T1, T2, T3, T4>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, CancellationToken cancellationToken);
}

/// <summary>
/// Represents CLI command.
/// </summary>
public interface ICommand<T0, T1, T2, T3, T4, T5>
{
    /// <summary>
    /// Runs the command.
    /// </summary>
    Task ExecAsync(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, CancellationToken cancellationToken);
}
