using System.Diagnostics.CodeAnalysis;

namespace FkThat.Templates.ClassLib;

/// <summary>
/// The greeting class.
/// </summary>
public class Greeting
{
    /// <summary>
    /// Returns the greeting message.
    /// </summary>
    /// <param name="whoami">Who am I.</param>
    /// <returns>The greeting message.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="whoami"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="whoami"/> is blank.</exception>
    [SuppressMessage("Performance", "CA1822:Mark members as static")]
    public string SayHello(string whoami)
    {
        _ = whoami ?? throw new ArgumentNullException(nameof(whoami));

        if (string.IsNullOrWhiteSpace(whoami))
        {
            throw new ArgumentException("The argument must not be blank.", nameof(whoami));
        }

        return $"Hello, {whoami}!";
    }
}
