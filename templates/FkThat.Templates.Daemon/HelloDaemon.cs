using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FkThat.Templates.Daemon
{
    /// <summary>
    /// Sample <see cref="BackgroundService"/>.
    /// </summary>
    public class HelloDaemon : BackgroundService
    {
        private readonly ILogger<HelloDaemon> _logger;

        public HelloDaemon(ILogger<HelloDaemon> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method is called when the <see cref="IHostedService"/> starts. The implementation
        /// should return a task that represents the lifetime of the long running operation(s) being
        /// performed.
        /// </summary>
        /// <param name="stoppingToken">
        /// Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.
        /// </param>
        /// <returns>A <see cref="Task"/> that represents the long running operations.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization",
            "CA1303:Do not pass literals as localized parameters",
            Justification = "No locaization.")]
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                stoppingToken.ThrowIfCancellationRequested();
                _logger.LogInformation("Hello, World!");
                await Task.Delay(3000, stoppingToken).ConfigureAwait(false);
            }
        }
    }
}
