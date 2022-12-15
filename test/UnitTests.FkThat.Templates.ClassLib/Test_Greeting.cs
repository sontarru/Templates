namespace FkThat.Templates.ClassLib;

public class Test_Greeting
{
    [Fact]
    public void SayHello_should_check_null_arg()
    {
        Greeting sut = new();
        sut.Invoking(s => s.SayHello(null!)).Should().Throw<ArgumentNullException>()
            .Which.ParamName.Should().Be("whoami");
    }

    [Fact]
    public void SayHello_should_check_empty_arg()
    {
        Greeting sut = new();
        sut.Invoking(s => s.SayHello(string.Empty)).Should().Throw<ArgumentException>()
            .Which.ParamName.Should().Be("whoami");
    }

    [Fact]
    public void SayHello_should_check_blank_arg()
    {
        Greeting sut = new();
        sut.Invoking(s => s.SayHello("   \t  \r\n")).Should().Throw<ArgumentException>()
            .Which.ParamName.Should().Be("whoami");
    }

    [Fact]
    public void SayHello_should_return_greeting()
    {
        Greeting sut = new();
        var actual = sut.SayHello("world");
        actual.Should().Be("Hello, world!");
    }
}
