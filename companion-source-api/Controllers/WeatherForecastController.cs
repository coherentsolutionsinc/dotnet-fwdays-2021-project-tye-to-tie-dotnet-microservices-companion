using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecastWithSource>> Get(
          [FromServices] WeatherClient client)
        {
            var weather = await client.GetWeatherAsync();

            var rng = new Random();
            return weather.Select(i => new WeatherForecastWithSource
            {
                Date = i.Date,
                TemperatureC = i.TemperatureC,
                Summary = i.Summary,
                Source = "Companion API"
            })
            .ToArray();
        }
    }
}
