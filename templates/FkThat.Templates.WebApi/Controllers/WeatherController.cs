using FkThat.Templates.WebApi.Models;

namespace FkThat.Templates.WebApi.Controllers;

/// <summary>
/// Represents a weather controller.
/// </summary>
/// <seealso cref="ControllerBase"/>
[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    /// <summary>
    /// Gets the weather forecast.
    /// </summary>
    [HttpGet("Forecast", Name = "GetWeatherForecast")]
    public IReadOnlyCollection<Weather> GetForecast() =>
        Enumerable.Range(0, 7).Select(i => new Weather(
            Date: DateTime.Today.AddDays(i),
            TemperatureC: Random.Shared.Next(-20, 41)))
        .ToArray();
}
