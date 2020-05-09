using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FkThat.Templates.WebSpa.Models
{
    public class WeatherModel
    {
        public DateTimeOffset Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }
    }
}
