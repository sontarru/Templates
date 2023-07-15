namespace FkThat.Templates.WebApi.Controllers;

/// <summary>
/// Represents weather.
/// </summary>
/// <param name="Date">The date of the weather.</param>
/// <param name="TemperatureC">The Celsius temperature.</param>
public record Weather(DateTime Date, int TemperatureC)
{
    /// <summary>
    /// Gets the Farenheit temperature.
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
