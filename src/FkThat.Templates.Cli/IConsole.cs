using System.IO;

namespace FkThat.Templates.Cli
{
    /// <summary>
    /// <see cref="System.Console"/> abstraction.
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Gets the standard output stream.
        /// </summary>
        /// <value>A <see cref="TextWriter"/> that represents the standard output stream.</value>
        TextWriter StdOut { get; }

        /// <summary>
        /// Gets the standard input stream.
        /// </summary>
        /// <value>A <see cref="TextReader"/> that represents the standard input stream.</value>
        TextReader StdIn { get; }

        /// <summary>
        /// Gets the standard error stream.
        /// </summary>
        /// <value>A <see cref="TextWriter"/> that represents the standard error stream.</value>
        TextWriter StdErr { get; }
    }
}
