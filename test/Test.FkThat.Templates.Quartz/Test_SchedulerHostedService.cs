using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Quartz;
using Quartz.Spi;
using Xunit;

namespace FkThat.Templates.Quartz
{
    public class Test_SchedulerHostedService
    {
        [Fact]
        public async Task StartAsync_ShouldScheduleJob()
        {
            var ctsrc = new CancellationTokenSource();
            var ct = ctsrc.Token;

            var schedulerFactory = A.Fake<ISchedulerFactory>();
            var scheduler = A.Fake<IScheduler>();
            var jobFactory = A.Fake<IJobFactory>();

            A.CallTo(() => schedulerFactory.GetScheduler(ct))
                .Returns(Task.FromResult(scheduler));

            var sut = new SchedulerHostedService(schedulerFactory, jobFactory);
            await sut.StartAsync(ct);

            A.CallTo(() => scheduler.ScheduleJob(
                A<IJobDetail>.That.Matches(x => x.JobType == typeof(HelloJob)),
                A<ITrigger>.Ignored, ct))
                .MustHaveHappened();
        }

        [Fact]
        public async Task StartAsync_ShouldStartScheduler()
        {
            var ctsrc = new CancellationTokenSource();
            var ct = ctsrc.Token;

            var schedulerFactory = A.Fake<ISchedulerFactory>();
            var scheduler = A.Fake<IScheduler>();
            var jobFactory = A.Fake<IJobFactory>();

            A.CallTo(() => schedulerFactory.GetScheduler(ct))
                .Returns(Task.FromResult(scheduler));

            var sut = new SchedulerHostedService(schedulerFactory, jobFactory);
            await sut.StartAsync(ct);

            // Should start scheduler
            A.CallTo(() => scheduler.Start(ct)).MustHaveHappened();
        }

        [Fact]
        public async Task StopAsync_ShouldStopScheduler()
        {
            var ctsrc = new CancellationTokenSource();
            var ct = ctsrc.Token;

            var schedulerFactory = A.Fake<ISchedulerFactory>();
            var scheduler = A.Fake<IScheduler>();
            var jobFactory = A.Fake<IJobFactory>();

            A.CallTo(() => schedulerFactory.GetScheduler(ct))
                .Returns(Task.FromResult(scheduler));

            var sut = new SchedulerHostedService(schedulerFactory, jobFactory);
            await sut.StartAsync(ct);
            await sut.StopAsync(ct);

            // Should start scheduler
            A.CallTo(() => scheduler.Shutdown(ct)).MustHaveHappened();
        }
    }
}
