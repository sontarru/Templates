namespace FkThat.Templates.ConsoleApp;

public class Test_CommandFactory
{
    public interface ITestCommand
    { }

    [Fact]
    public void Ctor_should_check_serviceProvider()
    {
        IServiceProvider serviceProvider = null!;
        FluentActions.Invoking(() => new CommandFactory(serviceProvider))
            .Should().Throw<ArgumentNullException>().Which
            .ParamName.Should().Be(nameof(serviceProvider));
    }

    [Fact]
    public void CreateCommand_should_return_command()
    {
        var serviceProvider = A.Fake<IServiceProvider>();
        TestCommand command = new();

        A.CallTo(() => serviceProvider.GetService(typeof(TestCommand)))
            .Returns(command);

        CommandFactory sut = new(serviceProvider);

        var actual = sut.CreateCommand<ITestCommand, TestCommand>();
        actual.Should().BeSameAs(command);
    }

    public class TestCommand : ITestCommand
    { }
}
