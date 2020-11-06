using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FkThat.Templates.WebApi.Models;

namespace FkThat.Templates.WebApi.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
            "CA1822:Mark members as static",
            Justification = "Actions should be instance methods")]
        [HttpGet("")]
        public IEnumerable<WeatherModel> GetWeather() => new[] {
          new WeatherModel {
            Date = new DateTimeOffset(2018, 05, 06, 00, 00, 00, TimeSpan.Zero),
            TemperatureC = 1,
            Summary = "Freezing"
          },
          new WeatherModel {
            Date = new DateTimeOffset(2018, 05, 07, 00, 00, 00, TimeSpan.Zero),
            TemperatureC = 14,
            Summary = "Bracing"
          },
          new WeatherModel {
            Date = new DateTimeOffset(2018, 05, 08, 00, 00, 00, TimeSpan.Zero),
            TemperatureC = -13,
            Summary = "Freezing"
          },
          new WeatherModel {
            Date = new DateTimeOffset(2018, 05, 09, 00, 00, 00, TimeSpan.Zero),
            TemperatureC = -16,
            Summary = "Balmy"
          },
          new WeatherModel {
            Date = new DateTimeOffset(2018, 05, 10, 00, 00, 00, TimeSpan.Zero),
            TemperatureC = -2,
            Summary = "Chilly"
          }
        };
    }
}
