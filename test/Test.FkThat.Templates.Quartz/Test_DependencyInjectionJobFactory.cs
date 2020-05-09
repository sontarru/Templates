using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Quartz;
using Quartz.Spi;
using Xunit;

namespace FkThat.Templates.Quartz
{
    public class Test_DependencyInjectionJobFactory
    {
        [Fact]
        public void NewJob_ShouldCreateJobWithServiceProvider()
        {
            var container = A.Fake<IServiceProvider>();
            var job = A.Fake<IJob>();
            var jobDetail = A.Fake<IJobDetail>();
            A.CallTo(() => container.GetService(typeof(Foo))).Returns(job);
            A.CallTo(() => jobDetail.JobType).Returns(typeof(Foo));

            var sut = new DependencyInjectionJobFactory(container);

            var result = sut.NewJob(
               new TriggerFiredBundle(
                   job: jobDetail,
                   trigger: default,
                   cal: default,
                   jobIsRecovering: default,
                   fireTimeUtc: default,
                   scheduledFireTimeUtc: default,
                   prevFireTimeUtc: default,
                   nextFireTimeUtc: default),
               scheduler: null);

            result.Should().BeSameAs(job);
        }

        [Fact]
        public void ReturnJob_ShouldDoNothing()
        {
            var container = A.Fake<IServiceProvider>();
            var sut = new DependencyInjectionJobFactory(container);
            sut.ReturnJob(A.Fake<IJob>());
            A.CallTo(container).MustNotHaveHappened();
        }

        public class Foo
        {
        }
    }
}
