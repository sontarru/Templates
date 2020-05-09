using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace FkThat.Templates.Quartz
{
    public class HelloJob : IJob
    {
        private readonly ILogger<HelloJob> _logger;

        public HelloJob(ILogger<HelloJob> logger)
        {
            _logger = logger;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization",
            "CA1303:Do not pass literals as localized parameters",
            Justification = "No localization yet.")]
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello, World!");
            return Task.CompletedTask;
        }
    }
}
