var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

#pragma warning disable CA1515,CS1591
public partial class Program { }
