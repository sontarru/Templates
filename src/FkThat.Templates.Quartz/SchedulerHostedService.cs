using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;

namespace FkThat.Templates.Quartz
{
    /// <summary>
    /// Quartz scheduler hosted service.
    /// </summary>
    public class SchedulerHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private IScheduler? _scheduler;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulerHostedService"/> class.
        /// </summary>
        /// <param name="schedulerFactory">The scheduler factory.</param>
        /// <param name="jobFactory">The job factory.</param>
        public SchedulerHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory)
        {
            _schedulerFactory = schedulerFactory;
            _jobFactory = jobFactory;
        }

        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">
        /// Indicates that the start process has been aborted.
        /// </param>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await _schedulerFactory
                .GetScheduler(cancellationToken).ConfigureAwait(false);

            await _scheduler.ScheduleJob(
                JobBuilder.Create<HelloJob>().Build(),
                TriggerBuilder.Create().WithSimpleSchedule(x =>
                    x.WithIntervalInSeconds(3).RepeatForever())
                    .Build(),
                cancellationToken)
                .ConfigureAwait(false);

            _scheduler.JobFactory = _jobFactory;
            await _scheduler.Start(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">
        /// Indicates that the shutdown process should no longer be graceful.
        /// </param>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_scheduler != null)
            {
                await _scheduler.Shutdown(cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
