using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace FkThat.Templates.Quartz
{
    /// <summary>
    /// Dependency injection quartz job factory.
    /// </summary>
    public class DependencyInjectionJobFactory : IJobFactory
    {
        private readonly IServiceProvider _container;

        /// <summary>
        /// Initializes a new instance of the <see cref="DependencyInjectionJobFactory"/> class.
        /// </summary>
        /// <param name="container">The service provider to create jobs.</param>
        public DependencyInjectionJobFactory(IServiceProvider container)
        {
            _container = container;
        }

        /// <summary>
        /// Creates new job.
        /// </summary>
        /// <param name="bundle">
        /// The TriggerFiredBundle from which the <see cref="Quartz.IJobDetail"/> and other info
        /// relating to the trigger firing can be obtained.
        /// </param>
        /// <param name="scheduler">
        /// a handle to the scheduler that is about to execute the job
        /// </param>
        /// <returns>the newly instantiated Job</returns>
        /// <remarks>
        /// It should be extremely rare for this method to throw an exception - basically only the
        /// case where there is no way at all to instantiate and prepare the Job for execution. When
        /// the exception is thrown, the Scheduler will move all triggers associated with the Job
        /// into the <see cref="Quartz.TriggerState.Error"/> state, which will require human
        /// intervention (e.g. an application restart after fixing whatever configuration problem
        /// led to the issue with instantiating the Job).
        /// </remarks>
        /// <throws>SchedulerException if there is a problem instantiating the Job.</throws>
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler) =>
            (IJob)_container.GetRequiredService(bundle.JobDetail.JobType);

        /// <summary>
        /// Allows the job factory to destroy/cleanup the job if needed.
        /// </summary>
        /// <param name="job">The job.</param>
        public void ReturnJob(IJob job)
        {
        }
    }
}
