using System;
using System.IO;

namespace FkThat.Templates.Cli
{
    /// <summary>
    /// <see cref="System.Console"/> adapter to <see cref="IConsole"/>.
    /// </summary>
    public class ConsoleAdapter : IConsole
    {
        /// <summary>
        /// Gets the standard output stream.
        /// </summary>
        /// <value>A <see cref="TextWriter"/> that represents the standard output stream.</value>
        public TextWriter StdOut => Console.Out;

        /// <summary>
        /// Gets the standard input stream.
        /// </summary>
        /// <value>A <see cref="TextReader"/> that represents the standard input stream.</value>
        public TextReader StdIn => Console.In;

        /// <summary>
        /// Gets the standard error stream.
        /// </summary>
        /// <value>A <see cref="TextWriter"/> that represents the standard error stream.</value>
        public TextWriter StdErr => Console.Error;
    }
}
