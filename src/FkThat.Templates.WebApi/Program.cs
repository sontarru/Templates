using System.Diagnostics.CodeAnalysis;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Configure services.

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    // configure CORS here
});

builder.Services.AddOpenApiDocument(configure => {
    configure.Title = "FkThat.Templates.WebApi";
});

// Build application.

var app = builder.Build();

// Configure application.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.UseOpenApi();

app.UseSwaggerUi3(configure => {
    configure.DocumentTitle = "FkThat.Templates.WebApi";
});

app.Run();

///<summary>
/// Reqiured for integration tests.
///</summary>
[SuppressMessage("Design", "CA1050:Declare types in namespaces", Justification =
    "This is added just to make the Program class public.")]
public partial class Program
{ }
