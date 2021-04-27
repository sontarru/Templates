using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FkThat.Tdd;

namespace FkThat.Templates.Cli
{
    /// <summary>
    /// Main application class.
    /// </summary>
    public class Application : IApplication
    {
        private readonly IConsole _console;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="console">The console.</param>
        public Application(IConsole console)
        {
            _console = console;
        }

        /// <summary>
        /// Runs the application asynchronously.
        /// </summary>
        /// <param name="args">The CLI arguments.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public async Task RunAsync(IEnumerable<string> args, CancellationToken cancellationToken)
        {
            await _console.Out.WriteLineAsync("Hello, world!").ConfigureAwait(false);
        }
    }
}
